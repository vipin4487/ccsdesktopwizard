namespace WWELib
{
    using Genesyslab.Platform.ApplicationBlocks.ConfigurationObjectModel.CfgObjects;
    using Genesyslab.Platform.ApplicationBlocks.ConfigurationObjectModel.Queries;
    using Genesyslab.Platform.Commons.Collections.Internal;
    using System;
    using System.Collections.Generic;
    using System.Collections.ObjectModel;
    using System.Linq;
    using System.Threading.Tasks;

    public class ComModelCrud : ComModelBase
    {
        public List<string> RequestBUNamesfromFolder(string folderName)
        {
            List<string> list2;
            List<string> list = new List<string>();
            Dictionary<string, List<string>> buNames = new Dictionary<string, List<string>>(StringComparer.InvariantCultureIgnoreCase);
            try
            {
                CfgFolderQuery query = new CfgFolderQuery(base.Service);
                query.set_Type(0x24);
                query.set_Name(folderName);
                ICollection<CfgFolder> source = query.Execute();
                List<string> values = new List<string>();
                if (source != null)
                {
                    Parallel.ForEach<CfgFolder>(source, delegate (CfgFolder folder) {
                        char[] separator = new char[] { '\\' };
                        string[] strArray = folder.get_ObjectPath().Split(separator);
                        string str2 = strArray[strArray.Length - 1];
                        ICollection<CfgObjectID> is2 = folder.get_ObjectIDs();
                        if ((is2 != null) && (is2.Count > 0))
                        {
                            Action<CfgObjectID> <>9__1;
                            ICollection<CfgEnumeratorValue> is3 = new Collection<CfgEnumeratorValue>();
                            Action<CfgObjectID> body = <>9__1;
                            if (<>9__1 == null)
                            {
                                Action<CfgObjectID> local1 = <>9__1;
                                body = <>9__1 = delegate (CfgObjectID cfgObject) {
                                    CfgEnumeratorValueQuery query = new CfgEnumeratorValueQuery(this.Service);
                                    query.set_Dbid(cfgObject.get_DBID());
                                    CfgEnumeratorValue value2 = query.ExecuteSingleResult();
                                    if (value2 != null)
                                    {
                                        value2.get_DBID();
                                        string key = value2.get_DBID().ToString();
                                        if (!buNames.ContainsKey(key))
                                        {
                                            values.Add(value2.get_Name());
                                        }
                                    }
                                };
                            }
                            Parallel.ForEach<CfgObjectID>(is2, body);
                        }
                    });
                }
                list2 = values.Distinct<string>().ToList<string>();
            }
            catch (Exception exception1)
            {
                throw exception1;
            }
            return list2;
        }

        public void RequestBUNamesfromFolder1(string folderName)
        {
            LogWriter logwrite = new LogWriter("start RequestBUNamesfromFolder" + DateTime.Now.ToString());
            Dictionary<string, List<string>> buNames = new Dictionary<string, List<string>>(StringComparer.InvariantCultureIgnoreCase);
            try
            {
                CfgFolderQuery query = new CfgFolderQuery(base.Service);
                query.set_Type(5);
                query.set_Name(folderName);
                ICollection<CfgFolder> source = query.Execute();
                List<string> values = new List<string>();
                if (source != null)
                {
                    Parallel.ForEach<CfgFolder>(source, delegate (CfgFolder folder) {
                        char[] separator = new char[] { '\\' };
                        string[] strArray = folder.get_ObjectPath().Split(separator);
                        string str2 = strArray[strArray.Length - 1];
                        ICollection<CfgObjectID> is2 = folder.get_ObjectIDs();
                        if ((is2 != null) && (is2.Count > 0))
                        {
                            Action<CfgObjectID> <>9__1;
                            ICollection<CfgEnumeratorValue> is3 = new Collection<CfgEnumeratorValue>();
                            Action<CfgObjectID> body = <>9__1;
                            if (<>9__1 == null)
                            {
                                Action<CfgObjectID> local1 = <>9__1;
                                body = <>9__1 = delegate (CfgObjectID cfgObject) {
                                    CfgAgentGroupQuery query = new CfgAgentGroupQuery(this.Service);
                                    query.set_Dbid(cfgObject.get_DBID());
                                    try
                                    {
                                        CfgAgentGroup group = query.ExecuteSingleResult();
                                        if (group != null)
                                        {
                                            group.get_DBID();
                                            string key = group.get_DBID().ToString();
                                            if (!buNames.ContainsKey(key))
                                            {
                                                foreach (object obj2 in group.get_GroupInfo().get_UserProperties().get_Values())
                                                {
                                                    foreach (string str2 in ((KeyValueCollectionBase<OrderedHashmapImpl>) obj2).get_AllKeys())
                                                    {
                                                        if (str2 == "teamcommunicator.corporate-favorites")
                                                        {
                                                            values.Add(group.get_GroupInfo().get_Name() + " :" + ((KeyValueCollectionBase<OrderedHashmapImpl>) obj2).get_Item(str2).ToString());
                                                            string[] textArray1 = new string[] { DateTime.Now.ToString(), "     ", group.get_GroupInfo().get_Name(), " :", ((KeyValueCollectionBase<OrderedHashmapImpl>) obj2).get_Item(str2).ToString() };
                                                            logwrite.LogWrite(string.Concat(textArray1));
                                                        }
                                                    }
                                                }
                                            }
                                        }
                                    }
                                    catch (Exception)
                                    {
                                    }
                                };
                            }
                            Parallel.ForEach<CfgObjectID>(is2, body);
                        }
                    });
                }
            }
            catch (Exception exception1)
            {
                throw exception1;
            }
        }
    }
}

