using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms;
using Newtonsoft.Json;
using ConsultaCep.Models;
using System.Net;

namespace ConsultaCep
{
    // Learn more about making custom code visible in the Xamarin.Forms previewer
    // by visiting https://aka.ms/xamarinforms-previewer
    [DesignTimeVisible(false)]
    public partial class MainPage : ContentPage
    {

        public MainPage()
        {
            InitializeComponent();

        }

        private async void btnCep_Clicked(object sender, EventArgs e)
        {
            try
            {

                WebClient wc = new WebClient();
                string Conteudo = wc.DownloadString($"http://viacep.com.br/ws/{TxtCep.Text}/json/");


                var endereco = JsonConvert.DeserializeObject<EnderecoCep>(Conteudo);
                if (endereco != null)
                {
                    txtCidade.Text = endereco.localidade;
                    txtUf.Text = endereco.uf;
                    txtRua.Text = endereco.logradouro;
                    txtBairro.Text = endereco.bairro;

                }


            }
            catch (Exception ex)
            {
                await DisplayAlert("Alerta", "Houve um erro na consulta", "OK");
            }

        }
    }
}
