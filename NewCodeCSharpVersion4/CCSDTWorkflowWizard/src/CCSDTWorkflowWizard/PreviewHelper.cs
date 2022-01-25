namespace CCSDTWorkflowWizard
{
    using AxSHDocVw;
    using CCSDTWorkflowLibrary;
    using mshtml;
    using System;
    using System.Collections.Generic;
    using System.Threading;
    using System.Windows.Forms;
    using WWELib;

    internal class PreviewHelper
    {
        private bool noUpdateAllowed = false;
        private CustomCCSDTWorkflowBase currentWorkflow = null;

        public PreviewHelper(CustomCCSDTWorkflowBase curWorkflow)
        {
            this.currentWorkflow = curWorkflow;
        }

        public void DisplayPreview(AxWebBrowser browserCtrl, Panel pnlCallVar, CallVariablesGridView dgCurrentCallVariables, Button btnCallVar)
        {
            this.InitUserInputControls(browserCtrl, dgCurrentCallVariables);
        }

        private void InitializeCallVarGrid(CallVariablesGridView dgCurrentCallVariables)
        {
            try
            {
            }
            catch (Exception exception)
            {
                AppLogger.AddMsg("**** ERROR: (PreviewHelper.InitializeCallVarGrid) " + exception.Message + "//" + exception.StackTrace.ToString(), AppLogger.LoggingLevelTypes.ApplicationExceptions);
            }
        }

        private void InitUserInputControls(AxWebBrowser browserCtrl)
        {
            throw new NotImplementedException();
        }

        private void InitUserInputControls(AxWebBrowser browserCtrl, CallVariablesGridView dgCurrentCallVariables)
        {
            try
            {
                ProcessGreeting_Text text = new ProcessGreeting_Text();
                Dictionary<string, string> omniKvps = null;
                string htmlText = text.ProcessGreetingText(omniKvps, this.currentWorkflow.GetHtml);
                this.LoadBrowserControl(browserCtrl, htmlText);
                browserCtrl.SuspendLayout();
                IHTMLDocument2 document = (IHTMLDocument2) browserCtrl.get_Document();
                foreach (IHTMLElement element in document.all)
                {
                    if (element is IHTMLInputElement)
                    {
                        HTMLInputElement element2 = (HTMLInputElement) element;
                        if (element2.type > null)
                        {
                            if (element2.type == "text")
                            {
                                if (this.noUpdateAllowed)
                                {
                                    element2.disabled = true;
                                }
                            }
                            else if (((element2.type != "radio") && (element2.type == "checkbox")) && this.noUpdateAllowed)
                            {
                                element2.disabled = true;
                            }
                        }
                    }
                    else if (element is IHTMLSelectElement)
                    {
                        HTMLSelectElement element3 = (HTMLSelectElement) element;
                    }
                    else if (element is IHTMLOptionElement)
                    {
                        HTMLOptionElement element4 = (HTMLOptionElement) element;
                    }
                    else if (element is IHTMLTextAreaElement)
                    {
                        HTMLTextAreaElement element5 = (HTMLTextAreaElement) element;
                        if (this.noUpdateAllowed)
                        {
                            element5.disabled = true;
                        }
                    }
                }
                browserCtrl.ResumeLayout();
                IHTMLWindow2 parentWindow = document.parentWindow;
                if (parentWindow > null)
                {
                    string language = "javascript";
                    string str3 = "stateMachine";
                    string[] textArray1 = new string[] { "if (window.", str3, ") {", str3, "('init');};" };
                    string code = string.Concat(textArray1);
                    try
                    {
                        parentWindow.execScript(code, language);
                    }
                    catch (Exception exception)
                    {
                        AppLogger.AddMsg("ERROR: (PreviewHelper.InitUserInputControls.execScript) " + exception.Message, AppLogger.LoggingLevelTypes.Errors);
                    }
                }
            }
            catch (Exception exception2)
            {
                AppLogger.AddMsg("**** ERROR: (PreviewHelper.InitUserInputControls) " + exception2.Message + "//" + exception2.StackTrace.ToString(), AppLogger.LoggingLevelTypes.ApplicationExceptions);
            }
        }

        private void LoadBrowserControl(AxWebBrowser browserCtrl, string htmlText)
        {
            try
            {
                browserCtrl.Navigate("about:blank");
                browserCtrl.Navigate("");
                int num = 0;
                IHTMLDocument2 document = (IHTMLDocument2) browserCtrl.get_Document();
                while ((num < 50) & (document == null))
                {
                    Thread.Sleep(200);
                    document = (IHTMLDocument2) browserCtrl.get_Document();
                    num++;
                }
                if (document != null)
                {
                    object[] psarray = new object[] { htmlText };
                    document.write(psarray);
                    document.close();
                }
            }
            catch (Exception exception)
            {
                AppLogger.AddMsg("**** ERROR: (PreviewHelper.LoadBrowserControl) " + exception.Message + "//" + exception.StackTrace.ToString(), AppLogger.LoggingLevelTypes.ApplicationExceptions);
            }
        }
    }
}

