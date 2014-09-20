using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Reflection;

namespace UmbDocTypeAliasGenerator
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void txtUsitebuilderAssembly_Click(object sender, EventArgs e)
        {
            OpenFileDialog d = new OpenFileDialog();
            if (d.ShowDialog() == System.Windows.Forms.DialogResult.OK)
            {
                txtUsitebuilderAssembly.Text = d.FileName;
            }
        }

        StringBuilder _CoderBuilder = new StringBuilder();
        List<string> _BuildFields = new List<string>();
        private void btnGenUsitebuilder_Click(object sender, EventArgs e)
        {
            try
            {
                if (AssemblyFileIsValid(txtUsitebuilderAssembly.Text.Trim()))
                {
                    _CoderBuilder.Clear();
                    _CoderBuilder.Length = 0;
                    _BuildFields.Clear();

                    var ass = Assembly.LoadFile(txtUsitebuilderAssembly.Text);
                    foreach (var t in ass.GetTypes().Where(t => Attribute.IsDefined(t, typeof(Vega.USiteBuilder.DocumentTypeAttribute))))
                    {
                        GenerateSingleDocType(t, ref _CoderBuilder, ref _BuildFields);
                    }

                    if (_CoderBuilder.Length > 0)
                    {
                        MessageBox.Show(
                            "Congratulations! Code generated in the clipboard now!"
                             , "Success"
                             , MessageBoxButtons.OK);

                        Clipboard.SetText(_CoderBuilder.ToString());
                    }
                    else
                    {
                        MessageBox.Show(
                            "No any code generated, please confirm you pick the right file."
                             , "Failure"
                             , MessageBoxButtons.OK);
                    }
                }
            }
            catch(Exception ex)
            {
                MessageBox.Show(
                    ex.Message
                     , "Failure"
                     , MessageBoxButtons.OK);
            }
        }

        private bool AssemblyFileIsValid(string filePath)
        {
            return true;
        }

        private void GenerateSingleDocType(Type docType, ref StringBuilder codeBuilder, ref List<string> builtFields)
        {
            codeBuilder.AppendLine();
            codeBuilder.AppendLine(String.Format("#region {0}", docType.Name));
            codeBuilder.AppendLine(String.Format("public const string {0} = \"{0}\";", docType.Name));
            codeBuilder.AppendLine();

            var baseDocType = docType.BaseType;
            var basePreperties = baseDocType.GetProperties().Select(p => p.Name).ToList();
            foreach (var p in docType.GetProperties().Where(p => !basePreperties.Contains(p.Name)))
            {
                var pname = p.Name;
                if (!builtFields.Contains(pname))
                {
                    var palias = "";
                    var pAttr = p.GetCustomAttribute(typeof(Vega.USiteBuilder.DocumentTypePropertyAttribute)) as Vega.USiteBuilder.DocumentTypePropertyAttribute;
                    if (!String.IsNullOrWhiteSpace(pAttr.Alias))
                    {
                        palias = pAttr.Alias;
                    }
                    else
                    {
                        palias = pname[0].ToString().ToLower() + pname.Substring(1, pname.Length - 1);
                    }
                    builtFields.Add(pname);
                    codeBuilder.AppendLine(String.Format("public const string {0} = \"{1}\";", pname, palias));
                }
            }

            codeBuilder.AppendLine("#endregion");
            codeBuilder.AppendLine();
        }
    }
}
