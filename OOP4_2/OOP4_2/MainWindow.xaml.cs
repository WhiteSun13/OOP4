using System;
using System.Text;
using System.Windows;
using System.Windows.Controls;

namespace OOP4_2
{
    // Enumerations Exercise 1
    /// <summary>
    /// Enumeration of girder material types
    /// </summary>
    public enum Material { StainlessSteel, Aluminium, ReinforcedConcrete, Composite, Titanium }
    /// <summary>
    /// Enumeration of girder cross-sections
    /// </summary>
    public enum CrossSection { IBeam, Box, ZShaped, CShaped }
    /// <summary>
    /// Enumeration of test results
    /// </summary>
    public enum TestResult { Pass, Fail }

    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
        }

        // Обработчик события изменения выбора в ListBox'ах
        private void SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            // Если не выбраны все три ListBox'а, то выходим из метода
            if (materialsListBox.SelectedItem == null || crosssectionsListBox.SelectedItem == null || testresultsListBox.SelectedItem == null)
                return;

            // Получаем выбранные значения из ListBox'ов
            Material selectedMaterial = (Material)((ListBoxItem)materialsListBox.SelectedItem).Tag;
            CrossSection selectedCrossSection = (CrossSection)((ListBoxItem)crosssectionsListBox.SelectedItem).Tag;
            TestResult selectedTestResult = (TestResult)((ListBoxItem)testresultsListBox.SelectedItem).Tag;

            // Создаем объект StringBuilder для формирования строки с выбранными значениями
            StringBuilder selectionStringBuilder = new StringBuilder();

            // Добавляем в строку выбранный материал
            switch (selectedMaterial)
            {
                case Material.StainlessSteel:
                    selectionStringBuilder.Append("Material: Stainless Steel, ");
                    break;
                case Material.Aluminium:
                    selectionStringBuilder.Append("Material: Aluminium, ");
                    break;
                case Material.ReinforcedConcrete:
                    selectionStringBuilder.Append("Material: Reinforced Concrete, ");
                    break;
                case Material.Composite:
                    selectionStringBuilder.Append("Material: Composite, ");
                    break;
                case Material.Titanium:
                    selectionStringBuilder.Append("Material: Titanium, ");
                    break;
            }

            // Добавляем в строку выбранное сечение
            switch (selectedCrossSection)
            {
                case CrossSection.IBeam:
                    selectionStringBuilder.Append("Cross-section: I-Beam, ");
                    break;
                case CrossSection.Box:
                    selectionStringBuilder.Append("Cross-section: Box, ");
                    break;
                case CrossSection.ZShaped:
                    selectionStringBuilder.Append("Cross-section: Z-Shaped, ");
                    break;
                case CrossSection.CShaped:
                    selectionStringBuilder.Append("Cross-section: C-Shaped, ");
                    break;
            }

            // Добавляем в строку результат тестирования
            switch (selectedTestResult)
            {
                case TestResult.Pass:
                    selectionStringBuilder.Append("Result: Pass.");
                    break;
                case TestResult.Fail:
                    selectionStringBuilder.Append("Result: Fail.");
                    break;
            }

            // Выводим сформированную строку в Label
            testDetailsLabel.Content = selectionStringBuilder.ToString();
        }
    }
}
