using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Base64Transforme
{
  public partial class Form1 : Form
  {
    public Form1()
    {
      InitializeComponent();
    }

    private void button1_Click(object sender, EventArgs e)
    {
      var pathOfFile = textBox1.Text;

      if(string.IsNullOrEmpty(pathOfFile))
      {
        MessageBox.Show("set the path of file");
        return;
      }

      var base64File = File.ReadAllText(pathOfFile);
      byte[] utf8Encoded = Encoding.UTF8.GetBytes(base64File);
      string base64String = Convert.ToBase64String(utf8Encoded);



      Regex regex = new Regex(@"^[\w/\:.-]+;base64,");
      base64File = regex.Replace(Encoding.UTF8.GetString(Convert.FromBase64String(base64String)), string.Empty);

      Clipboard.SetText(base64File);

      MessageBox.Show("Copied to CTRL + C");

      MessageBox.Show(base64File); 
    }
  }
}
