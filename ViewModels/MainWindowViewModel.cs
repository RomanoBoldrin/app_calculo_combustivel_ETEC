using System;
using System.Windows.Input;
using Avalonia.Controls;
using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;

namespace MeuCombustivelAvalonia.ViewModels
{
    public partial class MainWindowViewModel : ObservableObject
    {
        [ObservableProperty]
        private string etanol = string.Empty;

        [ObservableProperty]
        private string gasolina = string.Empty;

        [ObservableProperty]
        private string resultado = string.Empty;

        public MainWindowViewModel()
        {
            Resultado = "Preencha os valores e clique no botão.";
        }

        [RelayCommand]
        private void Calcular()
        {
            try
            {
                double precoEtanol = Convert.ToDouble(Etanol);
                double precoGasolina = Convert.ToDouble(Gasolina);

                if (precoEtanol <= precoGasolina * 0.7)
                {
                    Resultado = "O etanol está compensando.";
                }
                else
                {
                    Resultado = "A gasolina está compensando.";
                }
            }
            catch (Exception ex)
            {
                Resultado = $"Erro: {ex.Message}";
            }
        }
    }
}
