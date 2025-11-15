using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using System;

namespace MeuCombustivelAvalonia.ViewModels
{
    public partial class MainWindowViewModel : ObservableObject
    {
        [ObservableProperty] private string etanol = string.Empty;
        [ObservableProperty] private string gasolina = string.Empty;
        [ObservableProperty] private string marca = string.Empty;
        [ObservableProperty] private string modelo = string.Empty;
        [ObservableProperty] private string resultado = string.Empty;

        [RelayCommand]
        private void Calcular()
        {
            try
            {
                double precoEtanol = Convert.ToDouble(Etanol);
                double precoGasolina = Convert.ToDouble(Gasolina);

                if (string.IsNullOrWhiteSpace(Marca) || string.IsNullOrWhiteSpace(Modelo))
                {
                    Resultado = "Preencha a marca e o modelo do veículo.";
                    return;
                }

                if (precoEtanol <= (precoGasolina * 0.7))
                {
                    Resultado = $"O etanol está compensando para o seu {Marca} {Modelo}.";
                }
                else
                {
                    Resultado = $"A gasolina está compensando para o seu {Marca} {Modelo}.";
                }
            }
            catch
            {
                Resultado = "Preencha valores numéricos válidos para os combustíveis.";
            }
        }
    }
}
