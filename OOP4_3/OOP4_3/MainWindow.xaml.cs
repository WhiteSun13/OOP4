using System;
using System.Text;
using System.Windows;

namespace OOP4_3
{
    /// <summary>
    /// Логика взаимодействия для MainWindow.xaml
    /// </summary>

    public partial class MainWindow : Window
    {
        public static class TestManager
        {
            private static Random random = new Random();

            /// <summary>
            /// Генерация случайного результата теста
            /// </summary>
            /// <returns>TestCaseResult со случайным TestResult и причиной сбоя.</returns>
            public static TestCaseResult GenerateResult()
            {
                TestCaseResult result;

                TestResult testResult = (TestResult)random.Next(0, 2);
                result.Result = testResult;

                if (testResult == TestResult.Fail)
                {
                    result.ReasonForFailure = GetRandomReasonForFailure();
                }
                else
                {
                    result.ReasonForFailure = string.Empty;
                }

                return result;
            }

            /// <summary>
            /// Случайная причина сбоя.
            /// </summary>
            /// <returns>Причина сбоя в виде строки.</returns>
            private static string GetRandomReasonForFailure()
            {
                Material selectedMaterial = (Material)random.Next(0, 5);
                CrossSection selectedCrossSection = (CrossSection)random.Next(0, 4);

                StringBuilder selectionStringBuilder = new StringBuilder();
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
                selectionStringBuilder.Append("Result: Fail.");

                return selectionStringBuilder.ToString();
            }
        }
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
        // Structures Exercise 2
        /// <summary>
        /// Structure containing test results
        /// </summary>
        public struct TestCaseResult
        {
            /// <summary>
            /// Test result (enumeration type)
            /// </summary>
            public TestResult Result;
            /// <summary>
            /// Description of reason for failure
            /// </summary>
            public string ReasonForFailure;
        }

        private TestCaseResult[] results;

        public MainWindow()
        {
            InitializeComponent();
        }

        // Обработчик нажатия на кнопку "Run Tests"
        private void RunTests_Click(object sender, RoutedEventArgs e)
        {
            // Создаем массив для хранения результатов тестов
            results = new TestCaseResult[10];

            // Генерируем результаты тестов и сохраняем их в массив
            for (int i = 0; i < 10; i++)
            {
                results[i] = TestManager.GenerateResult();
            }

            // Счётчики успешных и неуспешных тестов
            int passCount = 0;
            int failCount = 0;

            // Очищаем список причин неуспешных тестов
            reasonsList.Items.Clear();

            // Проходим по всем результатам тестов и увеличиваем соответствующие счетчики
            // Если тест не прошел, добавляем причину неуспешности в список
            foreach (var result in results)
            {
                if (result.Result == TestResult.Pass)
                {
                    passCount++;
                }
                else if (result.Result == TestResult.Fail)
                {
                    failCount++;
                    reasonsList.Items.Add(result.ReasonForFailure);
                }
            }

            // Обновляем текстовые поля с количеством успешных и неуспешных тестов
            successesCount.Text = $"Successes: {passCount}";
            failuresCount.Text = $"Failures: {failCount}";
        }
    }
}
