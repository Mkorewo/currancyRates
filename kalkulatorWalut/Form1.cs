namespace kalkulatorWalut
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
            var currencyRequestManager = new CurrencyRequestManager();
            
            var usdExchangeRate = currencyRequestManager.GetUsdExchangeRate();
            var chfExchangeRate = currencyRequestManager.GetChfExchangeRate();
            var tryExchangeRate = currencyRequestManager.GetTryExchangeRate();
            var goldExchangeRate = currencyRequestManager.GetGoldExchangeRate();

            label2.Text = usdExchangeRate;
            label4.Text = chfExchangeRate;
            label6.Text = tryExchangeRate;
            label8.Text = goldExchangeRate;

        }

        private void label1_Click(object sender, EventArgs e)
        {

        }
    }
}