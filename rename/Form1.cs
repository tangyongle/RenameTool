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
            // 创建一个字符串数组，表示ComboBox的项目
            string[] items = { "替换文件中的字符", "文件增加前缀", "文件增加后缀", "文件名全部小写", "文件名全部大写" };

            // 将项目添加到ComboBox的项属性
            comboBox1.Items.AddRange(items);

            // 设置选择的索引为0，即第一项
            comboBox1.SelectedIndex = 0;

            // 添加事件处理程序来处理选择项的更改
            comboBox1.SelectedIndexChanged += comboBox1_SelectedIndexChanged;
            comboBox1_SelectedIndexChanged(null, null);

        }

        private void button1_Click(object sender, EventArgs e)
        {
            _errorStr = "";
            if (string.IsNullOrWhiteSpace(txtPath.Text))
            {
                MessageBox.Show("必须填入绝对地址", "提示", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }
            if (!Directory.Exists(txtPath.Text))
            {
                MessageBox.Show("目录不存在", "提示", MessageBoxButtons.OK, MessageBoxIcon.Information);
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
                    MessageBox.Show("请输入需要替换的字符串", "提示", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    return;
                }
            }
            else if (_curType == 1 || _curType == 2)
            {
                _newStr = txtAddStr.Text;

                if (string.IsNullOrWhiteSpace(TxtOld.Text))
                {
                    MessageBox.Show("请输入需要添加的字符串", "提示", MessageBoxButtons.OK, MessageBoxIcon.Information);
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
                        //批量替换字符
                        BatchReplaceStr(file, true);
                    }
                    else if (_curType == 1)
                    {
                        //文件增加前缀
                        BatchAddHead(file);
                    }
                    else if (_curType == 2)
                    {
                        //文件增加后缀
                        BatchAddPostfix(file);
                    }
                    else if (_curType == 3)
                    {
                        //文件名全部小写
                        BatchAddUpperOrLower(file, false);
                    }
                    else if (_curType == 4)
                    {
                        //文件名全部大写
                        BatchAddUpperOrLower(file, true);
                    }
                }
            }

            if (string.IsNullOrWhiteSpace(_errorStr))
            {
                MessageBox.Show("操作成功");
            }
            else
            {
                MessageBox.Show(_errorStr, "操作失败");
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
                    _errorStr += $"操作失败:路径[{_path + "/" + fileName}]->[{_path + "/" + newStr}]\n";
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
                    LabelAddStr.Text = "前缀";
                    break;
                case 2:
                    groupAdd.Visible = true;
                    groupRpt.Visible = false;
                    LabelAddStr.Text = "后缀";
                    break;
            }
        }


    }
}