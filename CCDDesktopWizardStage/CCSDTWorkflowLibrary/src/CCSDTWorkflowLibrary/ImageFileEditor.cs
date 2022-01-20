namespace CCSDTWorkflowLibrary
{
    using System;
    using System.ComponentModel;
    using System.ComponentModel.Design;
    using System.Drawing;
    using System.Drawing.Design;
    using System.Drawing.Imaging;
    using System.IO;
    using System.Windows.Forms;
    using System.Windows.Forms.Design;

    public class ImageFileEditor : UITypeEditor
    {
        public override object EditValue(ITypeDescriptorContext context, IServiceProvider provider, object value)
        {
            try
            {
                IWindowsFormsEditorService service = null;
                if (((context != null) && (provider != null)) && (context.Instance != null))
                {
                    service = (IWindowsFormsEditorService) provider.GetService(typeof(IWindowsFormsEditorService));
                }
                if (service != null)
                {
                    if (!string.IsNullOrEmpty((provider.GetService(typeof(IDesignerHost)) as IDesignerHost).RootComponentClassName))
                    {
                        OpenFileDialog dialog = new OpenFileDialog {
                            AddExtension = true,
                            Filter = "Image Files(*.bmp;*.jpg;*.gif;*.png)|*.bmp;*.jpg;*.gif;*.png"
                        };
                        if (dialog.ShowDialog() == DialogResult.OK)
                        {
                            ImageButton instance = context.Instance as ImageButton;
                            if (dialog.FileName.Length <= 0)
                            {
                                instance.ImageHeight = 0;
                                instance.ImageWidth = 0;
                                value = "";
                            }
                            else
                            {
                                try
                                {
                                    Bitmap bitmap = new Bitmap(dialog.FileName);
                                    MemoryStream stream = new MemoryStream();
                                    bitmap.Save(stream, ImageFormat.Png);
                                    string str2 = Convert.ToBase64String(stream.ToArray());
                                    if (str2.Length > 0x8000)
                                    {
                                        stream = new MemoryStream();
                                        bitmap.Save(stream, ImageFormat.Jpeg);
                                        str2 = Convert.ToBase64String(stream.ToArray());
                                    }
                                    if (str2.Length > 0x8000)
                                    {
                                        ImageCodecInfo encoder = null;
                                        ImageCodecInfo[] imageEncoders = ImageCodecInfo.GetImageEncoders();
                                        int index = 0;
                                        while (true)
                                        {
                                            if (index >= imageEncoders.Length)
                                            {
                                                if (encoder != null)
                                                {
                                                    EncoderParameters encoderParams = new EncoderParameters(1);
                                                    stream = new MemoryStream();
                                                    encoderParams.Param[0] = new EncoderParameter(Encoder.Quality, (long) 50);
                                                    bitmap.Save(stream, encoder, encoderParams);
                                                    str2 = Convert.ToBase64String(stream.ToArray());
                                                    if (str2.Length > 0x8000)
                                                    {
                                                        stream = new MemoryStream();
                                                        encoderParams.Param[0] = new EncoderParameter(Encoder.Quality, (long) 0x19);
                                                        bitmap.Save(stream, encoder, encoderParams);
                                                        str2 = Convert.ToBase64String(stream.ToArray());
                                                    }
                                                    if (str2.Length > 0x8000)
                                                    {
                                                        stream = new MemoryStream();
                                                        encoderParams.Param[0] = new EncoderParameter(Encoder.Quality, (long) 10);
                                                        bitmap.Save(stream, encoder, encoderParams);
                                                        str2 = Convert.ToBase64String(stream.ToArray());
                                                    }
                                                    if (str2.Length > 0x8000)
                                                    {
                                                        stream = new MemoryStream();
                                                        encoderParams.Param[0] = new EncoderParameter(Encoder.Quality, 5L);
                                                        bitmap.Save(stream, encoder, encoderParams);
                                                        str2 = Convert.ToBase64String(stream.ToArray());
                                                    }
                                                }
                                                break;
                                            }
                                            ImageCodecInfo info2 = imageEncoders[index];
                                            if (string.Compare("image/jpeg", info2.MimeType, true) == 0)
                                            {
                                                encoder = info2;
                                            }
                                            index++;
                                        }
                                    }
                                    if (str2.Length > 0x8000)
                                    {
                                        DialogResult result = MessageBox.Show("Selected image size is: " + str2.Length.ToString() + " bytes, 32768 is the limit.", "Error Loading Image", MessageBoxButtons.OK, MessageBoxIcon.Hand);
                                    }
                                    else
                                    {
                                        value = str2;
                                        instance.ImageHeight = bitmap.Height;
                                        instance.ImageWidth = bitmap.Width;
                                    }
                                }
                                catch (Exception exception1)
                                {
                                    DialogResult result2 = MessageBox.Show(exception1.Message, "Error Loading Image", MessageBoxButtons.OK, MessageBoxIcon.Hand);
                                }
                            }
                        }
                    }
                    else
                    {
                        return null;
                    }
                }
            }
            catch (Exception exception3)
            {
                MessageBox.Show(exception3.ToString());
            }
            return value;
        }

        public override UITypeEditorEditStyle GetEditStyle(ITypeDescriptorContext context) => 
            UITypeEditorEditStyle.Modal;
    }
}

