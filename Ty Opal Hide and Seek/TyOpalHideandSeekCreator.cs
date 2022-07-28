using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.IO;
using System.Reflection;

namespace Ty_Opal_Hide_and_Seek
{
    public partial class TyOpalHideandSeekCreator : Form
    {
        public TyOpalHideandSeekCreator()
        {
            InitializeComponent();
            saveFile.DefaultExt = ".seek";
            saveFile.AddExtension = true;
            FileIndicator.Text = "Open File: New File*";
            currentFileName = null;
            typos = new Typosrot();
            unpatchedDLL = "Resources/OpenAL32UNPATCHED.dll";
            patchedDLL = "Resources/OpenAL32PATCHED.dll";
            DLLPatchIndicator.Text = "Select Ty.exe Folder";
            EnableTextBoxShortcuts();
        }

        public Typosrot typos;
        public string PCExternalPath;
        public string baseFolderPath;
        public string tyexeFolderPath;
        private string currentFilePath;
        private string currentFileName;
        public string a1path;
        public string a2path;
        public string a3path;
        public string b1path;
        public string b2path;
        public string b3path;
        public string c1path;
        public string c2path;
        public string c3path;
        public string z1path;
        public string e1path;
        public string d2path;
        public string e4path;
        private bool loadCancelled;
        public string unpatchedDLL;
        public string patchedDLL;


        private void tableLayoutPanel1_Paint(object sender, PaintEventArgs e)
        {

        }

        private void folderBrowserDialog1_HelpRequest(object sender, EventArgs e)
        {

        }

        private void TyOpalHideandSeekCreator_Load(object sender, EventArgs e)
        {

        }

        //BUTTON CLICK TO SELECT BASE FOLDER
        private void SelectBaseFolderButton_Click(object sender, EventArgs e)
        {
            DialogResult baseFolderResult = SelectBaseFolder.ShowDialog();
            if (CheckBaseFolder())
            {
                baseFolderResult = DialogResult.OK;
                BaseFolderPathLabel.Text = "Base folder selected successfully";
                baseFolderPath = SelectBaseFolder.SelectedPath;
                return;
            }
            baseFolderResult = DialogResult.Abort;
            BaseFolderPathLabel.Text = "Folder does not contain lv2s";
        }

        //BUTTON CLICK TO SELECT PC_EXTERNAL
        private void SelectPCExternalButton_Click(object sender, EventArgs e)
        {
            DialogResult PCExternalResult = SelectPCExternal.ShowDialog();
            switch (CheckPCExternal())
            {
                case 0:
                    {
                        PCExternalPathLabel.Text = "Active lv2s already exist in folder. Move and retry or uncheck unwanted lv2s.";
                        PCExternalResult = DialogResult.Abort;
                        break;
                    }
                case 1:
                    {
                        PCExternalPathLabel.Text = "Folder is not PC_External.";
                        PCExternalResult = DialogResult.Abort;
                        break;
                    }
                case 2:
                    {
                        PCExternalPathLabel.Text = "PC_External selected sucessfully";
                        PCExternalPath = SelectPCExternal.SelectedPath;
                        PCExternalResult = DialogResult.OK;
                        break;
                    }

            }
        }

        //CHECK IF BASE FOLDER HAS LV2s
        private bool CheckBaseFolder()
        {
            if (
                File.Exists(SelectBaseFolder.SelectedPath + "/a1.lv2") &&
                File.Exists(SelectBaseFolder.SelectedPath + "/a2.lv2") &&
                File.Exists(SelectBaseFolder.SelectedPath + "/a3.lv2") &&
                File.Exists(SelectBaseFolder.SelectedPath + "/b1.lv2") &&
                File.Exists(SelectBaseFolder.SelectedPath + "/b2.lv2") &&
                File.Exists(SelectBaseFolder.SelectedPath + "/b3.lv2") &&
                File.Exists(SelectBaseFolder.SelectedPath + "/c1.lv2") &&
                File.Exists(SelectBaseFolder.SelectedPath + "/c2.lv2") &&
                File.Exists(SelectBaseFolder.SelectedPath + "/c3.lv2") &&
                File.Exists(SelectBaseFolder.SelectedPath + "/z1.lv2") &&
                File.Exists(SelectBaseFolder.SelectedPath + "/e1.lv2") &&
                File.Exists(SelectBaseFolder.SelectedPath + "/d2.lv2") &&
                File.Exists(SelectBaseFolder.SelectedPath + "/e4.lv2")
                )
            {
                return true;
            }
            return false;
        }

        //CHECK IF PC_EXTERNAL IS NAMED CORRECTLY AND AVOID OVERWRITING LV2s
        private int CheckPCExternal()
        {
            if (
                File.Exists(SelectPCExternal.SelectedPath + "/a1.lv2") && a1on.Checked ||
                File.Exists(SelectPCExternal.SelectedPath + "/a2.lv2") && a2on.Checked ||
                File.Exists(SelectPCExternal.SelectedPath + "/a3.lv2") && a3on.Checked ||
                File.Exists(SelectPCExternal.SelectedPath + "/b1.lv2") && b1on.Checked ||
                File.Exists(SelectPCExternal.SelectedPath + "/b2.lv2") && b2on.Checked ||
                File.Exists(SelectPCExternal.SelectedPath + "/b3.lv2") && b3on.Checked ||
                File.Exists(SelectPCExternal.SelectedPath + "/c1.lv2") && c1on.Checked ||
                File.Exists(SelectPCExternal.SelectedPath + "/c2.lv2") && c2on.Checked ||
                File.Exists(SelectPCExternal.SelectedPath + "/c3.lv2") && c3on.Checked ||
                File.Exists(SelectPCExternal.SelectedPath + "/z1.lv2") && z1on.Checked ||
                File.Exists(SelectPCExternal.SelectedPath + "/e1.lv2") && e1on.Checked ||
                File.Exists(SelectPCExternal.SelectedPath + "/d2.lv2") && d2on.Checked ||
                File.Exists(SelectPCExternal.SelectedPath + "/e4.lv2") && e4on.Checked
                )
            {
                return 0;
            }
            if (!SelectPCExternal.SelectedPath.EndsWith("PC_External"))
            {
                return 1;
            }
            return 2;
        }

        //ASSIGN THE BASE LV2s TO VARIABLES
        private void AssignBaselv2s()
        {
            a1path = baseFolderPath + "/a1.lv2";
            a2path = baseFolderPath + "/a2.lv2";        
            a3path = baseFolderPath + "/a3.lv2";            
            b1path = baseFolderPath + "/b1.lv2";            
            b2path = baseFolderPath + "/b2.lv2";            
            b3path = baseFolderPath + "/b3.lv2";            
            c1path = baseFolderPath + "/c1.lv2";            
            c2path = baseFolderPath + "/c2.lv2";            
            c3path = baseFolderPath + "/c3.lv2";            
            z1path = baseFolderPath + "/z1.lv2";            
            e1path = baseFolderPath + "/e1.lv2";            
            d2path = baseFolderPath + "/d2.lv2";            
            e4path = baseFolderPath + "/e4.lv2";            
        }

        //COPY BASE LV2s FOR EDIITING INTO THE PC_EXTERNAL FOLDER
        private void Copylv2s()
        {
            if (a1on.Checked) { File.Copy(a1path, PCExternalPath + "/a1.lv2"); a1path = PCExternalPath + "/a1.lv2"; }
            if (a2on.Checked) { File.Copy(a2path, PCExternalPath + "/a2.lv2"); a2path = PCExternalPath + "/a2.lv2"; }
            if (a3on.Checked) { File.Copy(a3path, PCExternalPath + "/a3.lv2"); a3path = PCExternalPath + "/a3.lv2"; }
            if (b1on.Checked) { File.Copy(b1path, PCExternalPath + "/b1.lv2"); b1path = PCExternalPath + "/b1.lv2"; }
            if (b2on.Checked) { File.Copy(b2path, PCExternalPath + "/b2.lv2"); b2path = PCExternalPath + "/b2.lv2"; }
            if (b3on.Checked) { File.Copy(b3path, PCExternalPath + "/b3.lv2"); b3path = PCExternalPath + "/b3.lv2"; }
            if (c1on.Checked) { File.Copy(c1path, PCExternalPath + "/c1.lv2"); c1path = PCExternalPath + "/c1.lv2"; }
            if (c2on.Checked) { File.Copy(c2path, PCExternalPath + "/c2.lv2"); c2path = PCExternalPath + "/c2.lv2"; }
            if (c3on.Checked) { File.Copy(c3path, PCExternalPath + "/c3.lv2"); c3path = PCExternalPath + "/c3.lv2"; }
            if (z1on.Checked) { File.Copy(z1path, PCExternalPath + "/z1.lv2"); z1path = PCExternalPath + "/z1.lv2"; }
            if (e1on.Checked) { File.Copy(e1path, PCExternalPath + "/e1.lv2"); e1path = PCExternalPath + "/e1.lv2"; }
            if (d2on.Checked) { File.Copy(d2path, PCExternalPath + "/d2.lv2"); d2path = PCExternalPath + "/d2.lv2"; }
            if (e4on.Checked) { File.Copy(e4path, PCExternalPath + "/e4.lv2"); e4path = PCExternalPath + "/e4.lv2"; }
        }

        //CHECK IF POS IS EMPTY
        private bool CheckPos(CheckBox check, TextBox x, TextBox y, TextBox z)
        {
            if (check.Checked)
            {
                if(x.TextLength == 0 || y.TextLength == 0 || z.TextLength == 0)
                {
                    return false;
                }
                return true;
            }
            return true;
        }

        //CHECK THAT ALL ACTIVE LV2s HAVE COORDINATES SPECIFIED
        private bool CheckValues()
        {
            if(
                CheckPos(a1on, a1xi, a1yi, a1zi) &&
                CheckPos(a2on, a2xi, a2yi, a2zi) &&
                CheckPos(a3on, a3xi, a3yi, a3zi) &&
                CheckPos(b1on, b1xi, b1yi, b1zi) &&
                CheckPos(b2on, b2xi, b2yi, b2zi) &&
                CheckPos(b3on, b3xi, b3yi, b3zi) &&
                CheckPos(c1on, c1xi, c1yi, c1zi) &&
                CheckPos(c2on, c2xi, c2yi, c2zi) &&
                CheckPos(c3on, c3xi, c3yi, c3zi) &&
                CheckPos(z1on, z1xi, z1yi, z1zi) &&
                CheckPos(e1on, e1xi, e1yi, e1zi) &&
                CheckPos(d2on, d2xi, d2yi, d2zi) &&
                CheckPos(e4on, e4xi, e4yi, e4zi)
                )
            {
                return true;
            }
            return false;
        }

        //EDIT LV2s TO APPEND OPALS
        private void Editlv2s()
        {
            currentProcess.Text = "Editing the lv2s";
            if (a1on.Checked)
            {
                File.AppendAllText(a1path, Environment.NewLine + "name OPAL" + Environment.NewLine + "pos = " + a1xi.Text + ", " + a1yi.Text + ", " + a1zi.Text + Environment.NewLine + "// User: " + signedInitials.Text);
            }      
            if (a2on.Checked)
            {
                File.AppendAllText(a2path, Environment.NewLine + "name OPAL" + Environment.NewLine + "pos = " + a2xi.Text + ", " + a2yi.Text + ", " + a2zi.Text + Environment.NewLine + "// User: " + signedInitials.Text);
            }            
            if (a3on.Checked)
            {
                File.AppendAllText(a3path, Environment.NewLine + "name OPAL" + Environment.NewLine + "pos = " + a3xi.Text + ", " + a3yi.Text + ", " + a3zi.Text + Environment.NewLine + "// User: " + signedInitials.Text);
            }            
            if (b1on.Checked)
            {
                File.AppendAllText(b1path, Environment.NewLine + "name OPAL" + Environment.NewLine + "pos = " + b1xi.Text + ", " + b1yi.Text + ", " + b1zi.Text + Environment.NewLine + "// User: " + signedInitials.Text);
            }            
            if (b2on.Checked)
            {
                File.AppendAllText(b2path, Environment.NewLine + "name OPAL" + Environment.NewLine + "pos = " + b2xi.Text + ", " + b2yi.Text + ", " + b2zi.Text + Environment.NewLine + "// User: " + signedInitials.Text);
            }          
            if (b3on.Checked)
            {
                File.AppendAllText(b3path, Environment.NewLine + "name OPAL" + Environment.NewLine + "pos = " + b3xi.Text + ", " + b3yi.Text + ", " + b3zi.Text + Environment.NewLine + "// User: " + signedInitials.Text);
            }            
            if (c1on.Checked)
            {
                File.AppendAllText(c1path, Environment.NewLine + "name OPAL" + Environment.NewLine + "pos = " + c1xi.Text + ", " + c1yi.Text + ", " + c1zi.Text + Environment.NewLine + "// User: " + signedInitials.Text);
            }            
            if (c2on.Checked)
            {
                File.AppendAllText(c2path, Environment.NewLine + "name OPAL" + Environment.NewLine + "pos = " + c2xi.Text + ", " + c2yi.Text + ", " + c2zi.Text + Environment.NewLine + "// User: " + signedInitials.Text);
            }            
            if (a2on.Checked)
            {
                File.AppendAllText(c3path, Environment.NewLine + "name OPAL" + Environment.NewLine + "pos = " + c3xi.Text + ", " + c3yi.Text + ", " + c3zi.Text + Environment.NewLine + "// User: " + signedInitials.Text);
            }            
            if (z1on.Checked)
            {
                File.AppendAllText(z1path, Environment.NewLine + "name OPAL" + Environment.NewLine + "pos = " + z1xi.Text + ", " + z1yi.Text + ", " + z1zi.Text + Environment.NewLine + "// User: " + signedInitials.Text);
            }            
            if (e1on.Checked)
            {
                File.AppendAllText(e1path, Environment.NewLine + "name OPAL" + Environment.NewLine + "pos = " + e1xi.Text + ", " + e1yi.Text + ", " + e1zi.Text + Environment.NewLine + "// User: " + signedInitials.Text);
            }            
            if (d2on.Checked)
            {
                File.AppendAllText(d2path, Environment.NewLine + "name OPAL" + Environment.NewLine + "pos = " + d2xi.Text + ", " + d2yi.Text + ", " + d2zi.Text + Environment.NewLine + "// User: " + signedInitials.Text);
            }            
            if (e4on.Checked)
            {
                File.AppendAllText(e4path, Environment.NewLine + "name OPAL" + Environment.NewLine + "pos = " + e4xi.Text + ", " + e4yi.Text + ", " + e4zi.Text + Environment.NewLine + "// User: " + signedInitials.Text);
            }            
        }

        //ALLOW ONLY DIGITS . AND - 
       /* private void digitOnly_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsControl(e.KeyChar) && !char.IsDigit(e.KeyChar) && (e.KeyChar != '.') && (e.KeyChar != '-'))
            {
                e.Handled = true;
            }

            if (e.KeyChar == '−')
            {
                e.Handled = true;
            }

            if (e.KeyChar == '.' && ((sender as TextBox).Text.IndexOf('.') > -1))
            {
                e.Handled = true;
            }
        }*/

        //BUTTON LOGIC FOR THE FINAL CREATE BUTTON
        private void Create_Click(object sender, EventArgs e)
        {
            if (CheckValues() && CheckPCExternal() == 2 && CheckBaseFolder() && signedInitials.TextLength != 0)
            {
                currentProcess.Text = "";
                Assigning.Visible = false;
                Copying.Visible = false;
                Reassigning.Visible = false;
                Editing.Visible = false;
                Placed.Visible = false;
                AssignBaselv2s();
                Assigning.Visible = true;
                Copylv2s();
                Copying.Visible = true;
                Reassigning.Visible = true;
                Editlv2s();
                Editing.Visible = true;
                Placed.Visible = true;
                return;
            }
            if (CheckPCExternal() != 2 || !CheckBaseFolder())
            {
                currentProcess.Text = "One or more of your folder paths is invalid";
                return;
            }
            if (!CheckValues())
            {
                currentProcess.Text = "One or more values have not been entered.";
                return;
            }
            currentProcess.Text = "Please input signature initials (Any 3 letters to help identify yourself)";
        }

        //SAVE MENU BUTTON
        private void saveToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if(currentFileName != saveFile.FileName || currentFileName == null)
            {
                DialogResult result = saveFile.ShowDialog();
                if (result == DialogResult.OK)
                {
                    currentFileName = saveFile.FileName;
                    currentFilePath = Path.GetFullPath(saveFile.FileName);
                    SaveFile(currentFilePath);
                    FileIndicator.Text = "Saved to " + currentFileName;
                    return;
                }
                return;
            }
            SaveFile(currentFilePath);
        }

        //SAVEAS MENU BUTTON
        private void saveAsToolStripMenuItem_Click(object sender, EventArgs e)
        {
            DialogResult result = saveFile.ShowDialog();
            if (result == DialogResult.OK)
            {
                currentFileName = saveFile.FileName;
                currentFilePath = Path.GetFullPath(saveFile.FileName);
                SaveFile(currentFilePath);
                FileIndicator.Text = "Saved to " + currentFileName;
            }
        }

        //FILE SAVING LOGIC
        private void SaveFile(string path)
        {
            if (currentFileName != null)
            {
                File.Delete(path);

                File.AppendAllText(path,
                    "SEEK FILE FOR TY OPAL HIDE AND SEEK CREATOR" + Environment.NewLine +
                    Environment.NewLine +
                    "PATHS" + Environment.NewLine +
                    "Base:" + Environment.NewLine +
                    baseFolderPath + Environment.NewLine +
                    "PC_External:" + Environment.NewLine +
                    PCExternalPath + Environment.NewLine +
                    Environment.NewLine +
                    "COORDINATES" + Environment.NewLine +
                    "a1 " + a1on.Checked.ToString() + Environment.NewLine +
                    a1xi.Text + Environment.NewLine +
                    a1yi.Text + Environment.NewLine +
                    a1zi.Text + Environment.NewLine +
                    "a2 " + a2on.Checked.ToString() + Environment.NewLine +
                    a2xi.Text + Environment.NewLine +
                    a2yi.Text + Environment.NewLine +
                    a2zi.Text + Environment.NewLine +
                    "a3 " + a3on.Checked.ToString() + Environment.NewLine +
                    a3xi.Text + Environment.NewLine +
                    a3yi.Text + Environment.NewLine +
                    a3zi.Text + Environment.NewLine +
                    "b1 " + b1on.Checked.ToString() + Environment.NewLine +
                    b1xi.Text + Environment.NewLine +
                    b1yi.Text + Environment.NewLine +
                    b1zi.Text + Environment.NewLine +
                    "b2 " + b2on.Checked.ToString() + Environment.NewLine +
                    b2xi.Text + Environment.NewLine +
                    b2yi.Text + Environment.NewLine +
                    b2zi.Text + Environment.NewLine +
                    "b3 " + b3on.Checked.ToString() + Environment.NewLine +
                    b3xi.Text + Environment.NewLine +
                    b3yi.Text + Environment.NewLine +
                    b3zi.Text + Environment.NewLine +
                    "c1 " + c1on.Checked.ToString() + Environment.NewLine +
                    c1xi.Text + Environment.NewLine +
                    c1yi.Text + Environment.NewLine +
                    c1zi.Text + Environment.NewLine +
                    "c2 " + c2on.Checked.ToString() + Environment.NewLine +
                    c2xi.Text + Environment.NewLine +
                    c2yi.Text + Environment.NewLine +
                    c2zi.Text + Environment.NewLine +
                    "c3 " + c3on.Checked.ToString() + Environment.NewLine +
                    c3xi.Text + Environment.NewLine +
                    c3yi.Text + Environment.NewLine +
                    c3zi.Text + Environment.NewLine +
                    "z1 " + z1on.Checked.ToString() + Environment.NewLine +
                    z1xi.Text + Environment.NewLine +
                    z1yi.Text + Environment.NewLine +
                    z1zi.Text + Environment.NewLine +
                    "e1 " + e1on.Checked.ToString() + Environment.NewLine +
                    e1xi.Text + Environment.NewLine +
                    e1yi.Text + Environment.NewLine +
                    e1zi.Text + Environment.NewLine +
                    "d2 " + d2on.Checked.ToString() + Environment.NewLine +
                    d2xi.Text + Environment.NewLine +
                    d2yi.Text + Environment.NewLine +
                    d2zi.Text + Environment.NewLine +
                    "e4 " + e4on.Checked.ToString() + Environment.NewLine +
                    e4xi.Text + Environment.NewLine +
                    e4yi.Text + Environment.NewLine +
                    e4zi.Text + Environment.NewLine +
                    Environment.NewLine +
                    "SIGNATURE" + Environment.NewLine +
                    signedInitials.Text + Environment.NewLine +
                    Environment.NewLine +
                    "END"
                    );
            }
        }

        //FILE LOADING LOGIC
        private void LoadFile(string path)
        {
            if ( path == "blank" ) { ClearTextBoxes(); CheckBoxes(); currentFileName = null; return; }
            string[] data = new string[67];
            int i = 1;
            foreach (string line in File.ReadLines(path)) { data[i] = line; i++; }
            baseFolderPath = data[5];
            PCExternalPath = data[7];
            a1xi.Text = data[11]; a1yi.Text = data[12]; a1zi.Text = data[13];
            a2xi.Text = data[15]; a2yi.Text = data[16]; a2zi.Text = data[17];
            a3xi.Text = data[19]; a3yi.Text = data[20]; a3zi.Text = data[21];
            b1xi.Text = data[23]; b1yi.Text = data[24]; b1zi.Text = data[25];
            b2xi.Text = data[27]; b2yi.Text = data[28]; b2zi.Text = data[29];
            b3xi.Text = data[31]; b3yi.Text = data[32]; b3zi.Text = data[33];
            c1xi.Text = data[35]; c1yi.Text = data[36]; c1zi.Text = data[37];
            c2xi.Text = data[39]; c2yi.Text = data[40]; c2zi.Text = data[41];
            c3xi.Text = data[43]; c3yi.Text = data[44]; c3zi.Text = data[45];
            z1xi.Text = data[47]; z1yi.Text = data[48]; z1zi.Text = data[49];
            e1xi.Text = data[51]; e1yi.Text = data[52]; e1zi.Text = data[53];
            d2xi.Text = data[55]; d2yi.Text = data[56]; d2zi.Text = data[57];
            e4xi.Text = data[59]; e4yi.Text = data[60]; e4zi.Text = data[61];
            signedInitials.Text = data[64];
            if (data[10].EndsWith("True")) { a1on.Checked = true; } else { a1on.Checked = false; }
            if (data[14].EndsWith("True")) { a2on.Checked = true; } else { a2on.Checked = false; }
            if (data[18].EndsWith("True")) { a3on.Checked = true; } else { a3on.Checked = false; }
            if (data[22].EndsWith("True")) { b1on.Checked = true; } else { b1on.Checked = false; }
            if (data[26].EndsWith("True")) { b2on.Checked = true; } else { b2on.Checked = false; }
            if (data[30].EndsWith("True")) { b3on.Checked = true; } else { b3on.Checked = false; }
            if (data[34].EndsWith("True")) { c1on.Checked = true; } else { c1on.Checked = false; }
            if (data[38].EndsWith("True")) { c2on.Checked = true; } else { c2on.Checked = false; }
            if (data[42].EndsWith("True")) { c3on.Checked = true; } else { c3on.Checked = false; }
            if (data[46].EndsWith("True")) { z1on.Checked = true; } else { z1on.Checked = false; }
            if (data[50].EndsWith("True")) { e1on.Checked = true; } else { e1on.Checked = false; }
            if (data[54].EndsWith("True")) { d2on.Checked = true; } else { d2on.Checked = false; }
            if (data[58].EndsWith("True")) { e4on.Checked = true; } else { e4on.Checked = false; }
        }

        //OPEN MENU BUTTON
        private void openToolStripMenuItem_Click(object sender, EventArgs e)
        {
            WarnSave();
            if (!loadCancelled)
            {
                DialogResult result = openFile.ShowDialog();
                if (result == DialogResult.OK && openFile.SafeFileName.EndsWith(".seek"))
                {
                    currentFileName = openFile.SafeFileName;
                    currentFilePath = Path.GetFullPath(openFile.FileName);
                    LoadFile(currentFilePath);
                    FileIndicator.Text = "Open File: " + currentFileName;
                    saveFile.FileName = currentFileName;
                }
            }
            return;
        }

        private void WarnSave()
        {
            loadCancelled = false;
            switch (MessageBox.Show("Warning, unsaved changes will be lost." + Environment.NewLine +  "Would you like to save?", Text, MessageBoxButtons.YesNoCancel, MessageBoxIcon.Warning))
            {
                case DialogResult.Yes:
                    SaveFile(currentFilePath);
                    break;
                case DialogResult.No:
                    break;
                case DialogResult.Cancel:
                    loadCancelled = true;
                    break;
            }
        }

        private void newToolStripMenuItem_Click(object sender, EventArgs e)
        {
            WarnSave();
            if (loadCancelled) { return; }
            LoadFile("blank");
            DLLPatchIndicator.Text = "Select Ty.exe Folder";
        }

        private void ClearTextBoxes()
        {
            Action<Control.ControlCollection> func = null;
            func = (controls) =>
            {
                foreach (Control control in controls)
                    if (control is TextBox)
                        (control as TextBox).Clear();
                    else
                        func(control.Controls);
            };
            func(Controls);
        }

        private void EnableTextBoxShortcuts()
        {
            Action<Control.ControlCollection> func = null;
            func = (controls) =>
            {
                foreach (Control control in controls)
                    if (control is TextBox)
                        (control as TextBox).ShortcutsEnabled = true;
                    else
                        func(control.Controls);
            };
            func(Controls);
        }

        private void CheckBoxes()
        {
            Action<Control.ControlCollection> func = null;
            func = (controls) =>
            {
                foreach (Control control in controls)
                    if (control is CheckBox)
                        (control as CheckBox).Checked = true;
                    else
                        func(control.Controls);
            };
            func(Controls);
        }

        private void calculateTyPosButton_Click(object sender, EventArgs e)
        {
            typos.GetTyPos();
            if (typos.typrocess != null)
            {
                if (typos.currentLevelID != 10)
                {
                    typosxvalue.Text = typos.floatTyPosX.ToString();
                    typosyvalue.Text = typos.floatTyPosY.ToString();
                    typoszvalue.Text = typos.floatTyPosZ.ToString();
                    TyPosIndicator.Text = "Ty coordinates retrieved successfully!";
                    return;
                }
                typosxvalue.Text = typos.floatBpPosX.ToString();
                typosyvalue.Text = typos.floatBpPosY.ToString();
                typoszvalue.Text = typos.floatBpPosZ.ToString();
                TyPosIndicator.Text = "BushPig coordinates retrieved successfully!";
                return;
            }
            TyPosIndicator.Text = "Ty.exe is not open. Open Ty and try again.";
        }

        private void CopyX_Click(object sender, EventArgs e)
        {
            if (typos.typrocess != null) { Clipboard.SetText(typosxvalue.Text); }
        }

        private void CopyY_Click(object sender, EventArgs e)
        {
            if (typos.typrocess != null) { Clipboard.SetText(typosyvalue.Text); }
        }

        private void CopyZ_Click(object sender, EventArgs e)
        {
            if (typos.typrocess != null) { Clipboard.SetText(typoszvalue.Text); }
        }

        private void SelectTyFolderButton_Click(object sender, EventArgs e)
        {
            DialogResult tyexeFolderResult = SelectTyFolder.ShowDialog();
            if (CheckTyFolder())
            {
                tyexeFolderResult = DialogResult.OK;
                DLLPatchIndicator.Text = "TY.exe folder selected successfully";
                tyexeFolderPath = SelectTyFolder.SelectedPath;
                return;
            }
            tyexeFolderResult = DialogResult.Abort;
            DLLPatchIndicator.Text = "Folder does not contain TY.exe";
        }

        private bool CheckTyFolder()
        {
            if (File.Exists(SelectTyFolder.SelectedPath + "/TY.exe")) { return true; }
            return false;
        }

        private void PatchDLLButton_Click(object sender, EventArgs e)
        {
            if (CheckTyFolder())
            {
                File.Delete(tyexeFolderPath + "/OpenAL32.DLL");
                File.Copy(patchedDLL, tyexeFolderPath + "/OpenAL32.DLL");
                DLLPatchIndicator.Text = "DLL Patched";
                return;
            }
            DLLPatchIndicator.Text = "Folder does not contain TY.exe";
        }

        private void UnpatchDLLButton_Click(object sender, EventArgs e)
        {
            if (CheckTyFolder())
            {
                File.Delete(tyexeFolderPath + "/OpenAL32.DLL");
                File.Copy(unpatchedDLL, tyexeFolderPath + "/OpenAL32.DLL");
                DLLPatchIndicator.Text = "DLL Unpatched";
                return;
            }
            DLLPatchIndicator.Text = "Folder does not contain TY.exe";
        }
    }
}
