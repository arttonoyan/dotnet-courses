using System;
using System.Net.Http;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace _011_Tasks_ConfigureAwait
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            //var syncContext = SynchronizationContext.Current;
            //var syncContextType = syncContext?.ToString();

            textBox1.Text = GetDataAsync().Result.ToString();
        }

        public static async Task<int> GetDataAsync()
        {
            using var client = new HttpClient();

            var data = await client
                .GetByteArrayAsync("https://github.com/");
                //.ConfigureAwait(false);

            return data.Length;
        }
    }
}
