using System.Diagnostics;
using System.Windows.Forms;

namespace rename
{
    public partial class Form1 : Form
    {
        private string _path;
        private string _oldStr;
        private string _newStr;
        private int _curType;
        private string _errorStr;

        public Form1()
        {
            InitializeComponent();
            // ����һ���ַ������飬��ʾComboBox����Ŀ
            string[] items = { "�滻�ļ��е��ַ�", "�ļ�����ǰ׺", "�ļ����Ӻ�׺", "�ļ���ȫ��Сд", "�ļ���ȫ����д" };

            // ����Ŀ��ӵ�ComboBox��������
            comboBox1.Items.AddRange(items);

            // ����ѡ�������Ϊ0������һ��
            comboBox1.SelectedIndex = 0;

            // ����¼��������������ѡ����ĸ���
            comboBox1.SelectedIndexChanged += comboBox1_SelectedIndexChanged;
            comboBox1_SelectedIndexChanged(null, null);

        }

        private void button1_Click(object sender, EventArgs e)
        {
            _errorStr = "";
            if (string.IsNullOrWhiteSpace(txtPath.Text))
            {
                MessageBox.Show("����������Ե�ַ", "��ʾ", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }
            if (!Directory.Exists(txtPath.Text))
            {
                MessageBox.Show("Ŀ¼������", "��ʾ", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }

            _path = txtPath.Text;
            _curType = comboBox1.SelectedIndex;
            if (_curType == 0)
            {
                _oldStr = TxtOld.Text;
                _newStr = TxtNew.Text;

                if (string.IsNullOrWhiteSpace(TxtOld.Text))
                {
                    MessageBox.Show("��������Ҫ�滻���ַ���", "��ʾ", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    return;
                }
            }
            else if (_curType == 1 || _curType == 2)
            {
                _newStr = txtAddStr.Text;

                if (string.IsNullOrWhiteSpace(TxtOld.Text))
                {
                    MessageBox.Show("��������Ҫ��ӵ��ַ���", "��ʾ", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    return;
                }
            }


            if (Directory.Exists(_path))
            {
                DirectoryInfo direction = new DirectoryInfo(_path);
                FileInfo[] files = direction.GetFiles("*.*", SearchOption.AllDirectories);
                foreach (var file in files)
                {
                    if (_curType == 0)
                    {
                        //�����滻�ַ�
                        BatchReplaceStr(file, true);
                    }
                    else if (_curType == 1)
                    {
                        //�ļ�����ǰ׺
                        BatchAddHead(file);
                    }
                    else if (_curType == 2)
                    {
                        //�ļ����Ӻ�׺
                        BatchAddPostfix(file);
                    }
                    else if (_curType == 3)
                    {
                        //�ļ���ȫ��Сд
                        BatchAddUpperOrLower(file, false);
                    }
                    else if (_curType == 4)
                    {
                        //�ļ���ȫ����д
                        BatchAddUpperOrLower(file, true);
                    }
                }
            }

            if (string.IsNullOrWhiteSpace(_errorStr))
            {
                MessageBox.Show("�����ɹ�");
            }
            else
            {
                MessageBox.Show(_errorStr, "����ʧ��");
            }
        }

        private void BatchReplaceStr(FileInfo file, bool isExtension)
        {
            if (isExtension)
            {
                var fileName = file.Name;
                string newStr = fileName.Replace(_oldStr, _newStr);
                try
                {
                    File.Move(_path + "/" + fileName, _path + "/" + newStr);
                }
                catch (Exception e)
                {
                    Console.WriteLine(e);
                    _errorStr += $"����ʧ��:·��[{_path + "/" + fileName}]->[{_path + "/" + newStr}]\n";
                }
            }
            else
            {
                var fileName = file.Name;
                var fileExtension = file.Extension;
                fileName = fileName.Replace(fileExtension, "");
                string newStr = fileName.Replace(_oldStr, _newStr);
                File.Move(_path + "/" + fileName + fileExtension, _path + "/" + newStr + fileExtension);
            }
        }

        private void BatchAddHead(FileInfo file)
        {
            var fileName = file.Name;
            var fileExtension = file.Extension;
            fileName = fileName.Replace(fileExtension, "");
            File.Move(_path + "/" + fileName + fileExtension, _path + "/" + _newStr + fileName + fileExtension);
        }

        private void BatchAddPostfix(FileInfo file)
        {
            var fileName = file.Name;
            var fileExtension = file.Extension;
            fileName = fileName.Replace(fileExtension, "");
            File.Move(_path + "/" + fileName + fileExtension, _path + "/" + fileName + _newStr + fileExtension);
        }
        private void BatchAddUpperOrLower(FileInfo file, bool isUpper)
        {
            var fileName = file.Name;
            var fileExtension = file.Extension;
            fileName = fileName.Replace(fileExtension, "");
            string endName = isUpper ? fileName.ToUpper() : fileName.ToLower();
            File.Move(_path + "/" + fileName + fileExtension, _path + "/" + endName + "^^" + fileExtension);
            File.Move(_path + "/" + endName + "^^" + fileExtension, _path + "/" + endName + fileExtension);
        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            var idx = comboBox1.SelectedIndex;
            switch (idx)
            {
                case 0:
                    groupRpt.Visible = true;
                    groupAdd.Visible = false;
                    break;
                case 1:
                    groupAdd.Visible = true;
                    groupRpt.Visible = false;
                    LabelAddStr.Text = "ǰ׺";
                    break;
                case 2:
                    groupAdd.Visible = true;
                    groupRpt.Visible = false;
                    LabelAddStr.Text = "��׺";
                    break;
            }
        }


    }
}