using System;
using System.Collections.Generic;
using System.Linq;
using System.Speech.Recognition;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;
using System.Windows.Controls.Primitives;
using NoteApps.ViewModel;
using System.IO;

namespace NoteApps.View
{
    /// <summary>
    /// Interaction logic for NoteWindow.xaml
    /// </summary>
    public partial class NoteWindow 
    {
        SpeechRecognitionEngine recognizer;
        NoteVM viewModel;
//Đã check
        public NoteWindow()
        {
            InitializeComponent();
            viewModel = new NoteVM();
            container.DataContext = viewModel;
            viewModel.SelectedNoteChanged += ViewModel_SelectedNoteChanged;
            viewModel.SelectedNotebookChanged += ViewModel_SelectedNotebookChanged;
            var currentCulture = (from r in SpeechRecognitionEngine.InstalledRecognizers()
                                  where r.Culture.Equals(Thread.CurrentThread.CurrentCulture)
                                  select r).FirstOrDefault();
            recognizer = new SpeechRecognitionEngine(currentCulture);
            GrammarBuilder builder = new GrammarBuilder();
            builder.AppendDictation();
            Grammar grammar = new Grammar(builder);
            recognizer.LoadGrammar(grammar);
            // đặt thiết bị input là thiết bị mình default trong maý
            recognizer.SetInputToDefaultAudioDevice();
            recognizer.SpeechRecognized += Recognizer_SpeechRecognized;
            //sẽ trả về 1 list font
            var fontFamilies = Fonts.SystemFontFamilies.OrderBy(f => f.Source);
            fontFamilyComboBox.ItemsSource = fontFamilies;
            //sẽ trả về 1 list font chữ. Nhưng Combobox này có thể chỉnh số bên trong được đã được định nghĩa trong file xmal
            List<double> fontSizes = new List<double>() { 8, 9, 10, 11, 12, 14, 28, 48, 72 };
            fontSizeComboBox.ItemsSource = fontSizes;
        }

        private void ViewModel_SelectedNotebookChanged(object sender, EventArgs e)
        {
            notebook_list.Items.Clear();
        }

        //check nhung chua day du
        // Có thể SelectedNoteChanged mà không có SelectedNotebookChange nên mình không thay đổi notebook được, thêm try catch nữa nhé lỡ có return null
        private void ViewModel_SelectedNoteChanged(object sender, EventArgs e)
        {
            contentRichTextBox.Document.Blocks.Clear();
            try
            {
                if (!string.IsNullOrEmpty(viewModel.SelectedNote.FileLocation))
                {

                    using (FileStream fileStream = new FileStream(viewModel.SelectedNote.FileLocation, FileMode.Open))
                    {
                        TextRange range = new TextRange(contentRichTextBox.Document.ContentStart, contentRichTextBox.Document.ContentEnd);
                        range.Load(fileStream, DataFormats.Rtf);
                    }
                }
            }
            catch
            {

            }
        }
        //check co sua loi
        protected override void OnActivated(EventArgs e)
        {
            base.OnActivated(e);
            if (string.IsNullOrEmpty(App.UserID))
            {
                LoginWindow loginWindow = new LoginWindow();
                loginWindow.ShowDialog();
                //bug:
                viewModel.ReadNotebooks();
            }
        }
        private void Recognizer_SpeechRecognized(object sender, SpeechRecognizedEventArgs e)
        {
            string recongizedText = e.Result.Text;
            contentRichTextBox.Document.Blocks.Add(new Paragraph(new Run(recongizedText)));
        }
        // đã check
        private void MenuItem_Click(object sender, RoutedEventArgs e)
        {
            Application.Current.Shutdown();
        }
        //đã check
        private void Button_Click(object sender, RoutedEventArgs e)
        {
            //Nếu ToggleButton của speech được nhấn (IsChecked) thì trả về giá trị là True và ngược lại
            bool isButtonEnabled = (sender as ToggleButton).IsChecked ?? false;
            if (isButtonEnabled)
            {
                recognizer.RecognizeAsync(RecognizeMode.Multiple);
            }
            else
            {
                recognizer.RecognizeAsyncStop();
            }
        }
        //đã check
        private void contentRichTextBox_TextChanged(object sender, TextChangedEventArgs e)
        {
            //ammoutCharacters là biến điếm số kí tự chúng ta đã viết. TextRange lấy từ điểm bắt đầu và tới điểm cuối văn bản
            int ammoutCharacters = (new TextRange(contentRichTextBox.Document.ContentStart, contentRichTextBox.Document.ContentEnd)).Text.Length;
            statusTextBlock.Text = $"Document length: {ammoutCharacters} characters";
        }
        //đã check
        private void boldButton_Click(object sender, RoutedEventArgs e)
        {

            //Đoạn ký tự được select ở contentRichTextBox sẽ được ApplyPropertyValue là FontWeightProperty mà giá trị của nó là Bold
            //
            bool isButtonEnabled = (sender as ToggleButton).IsChecked ?? false;
            if (isButtonEnabled)
                //nếu isButtonEnable là true thì định dạng văn bản sẽ là Bold
                contentRichTextBox.Selection.ApplyPropertyValue(Inline.FontWeightProperty, FontWeights.Bold);
            else
                //Nếu isButtonEnanle là false thì áp dụng định dạng văn bản sẽ là Normal
                contentRichTextBox.Selection.ApplyPropertyValue(Inline.FontWeightProperty, FontWeights.Normal);

        }
        //đã check
        private void contentRichTextBox_SelectionChanged(object sender, RoutedEventArgs e)
        {
            //lấy giá trị định dạng từ line mình đang selected
            var selectedState = contentRichTextBox.Selection.GetPropertyValue(Inline.FontWeightProperty);
            //boldButton.IsChecked sẽ trả về giá trị là true nếu dòng đó có dịnh dạng chữ và được định dạng là Bold. Nếu là True thì Toggle button của B sẽ được enable
            boldButton.IsChecked = (selectedState != DependencyProperty.UnsetValue) && (selectedState.Equals(FontWeights.Bold));
            //tương tự với định dạng nghiên
            var selectedStyle = contentRichTextBox.Selection.GetPropertyValue(Inline.FontStyleProperty);
            ItalicButton.IsChecked = (selectedStyle != DependencyProperty.UnsetValue) && (selectedStyle.Equals(FontStyles.Italic));
            // với định dạng gạch chân
            var selecteDecoration = contentRichTextBox.Selection.GetPropertyValue(Inline.TextDecorationsProperty);
            var selecteDecoration1 = contentRichTextBox.Selection.GetPropertyValue(Inline.TextDecorationsProperty);
            UnderlineButton.IsChecked = (selecteDecoration != DependencyProperty.UnsetValue) && (selecteDecoration.Equals(TextDecorations.Underline));
            
            Strikethrough.IsChecked = (selecteDecoration1 != DependencyProperty.UnsetValue) && (selecteDecoration1.Equals(TextDecorations.Strikethrough));
             fontFamilyComboBox.SelectedItem = contentRichTextBox.Selection.GetPropertyValue(Inline.FontFamilyProperty);
            fontSizeComboBox.Text = (contentRichTextBox.Selection.GetPropertyValue(Inline.FontSizeProperty)).ToString();
        }
        //đã check
        private void ItalicButton_Click(object sender, RoutedEventArgs e)
        {
            bool isButtonEnabled = (sender as ToggleButton).IsChecked ?? false;
            if (isButtonEnabled)
                contentRichTextBox.Selection.ApplyPropertyValue(Inline.FontStyleProperty, FontStyles.Italic);
            else
                contentRichTextBox.Selection.ApplyPropertyValue(Inline.FontStyleProperty, FontStyles.Normal);
        }
        //đã check
        private void UnderlineButton_Click(object sender, RoutedEventArgs e)
        {
            bool isButtonEnabled = (sender as ToggleButton).IsChecked ?? false;

            if (isButtonEnabled)
                contentRichTextBox.Selection.ApplyPropertyValue(Inline.TextDecorationsProperty, TextDecorations.Underline);
            else
            {
                TextDecorationCollection textDecorations;
                //đây là hàm sẽ xoá textdecoration underline của text đã định dạng và gán cho textdecroations
                (contentRichTextBox.Selection.GetPropertyValue(Inline.TextDecorationsProperty) as TextDecorationCollection).TryRemove(TextDecorations.Underline, out textDecorations);
                //đây là hàm sẽ áp định dạng văn bản kiểu đã được gán cho text Decorations
                contentRichTextBox.Selection.ApplyPropertyValue(Inline.TextDecorationsProperty, textDecorations);
            }
        }
        //đã check
        private void Strikethrough_Click(object sender, RoutedEventArgs e)
        {
            bool isButtonEnabled = (sender as ToggleButton).IsChecked ?? false;


            if (isButtonEnabled)
            {
                contentRichTextBox.Selection.ApplyPropertyValue(Inline.TextDecorationsProperty, TextDecorations.Strikethrough);

            }
            else
            {
                TextDecorationCollection textDecorations;
                //đây là hàm sẽ xoá textdecoration Strikethrough của text đã định dạng và gán cho textdecroations
                (contentRichTextBox.Selection.GetPropertyValue(Inline.TextDecorationsProperty) as TextDecorationCollection).TryRemove(TextDecorations.Strikethrough, out textDecorations);
                //đây là hàm sẽ áp định dạng văn bản kiểu đã được gán cho text Decorations
                contentRichTextBox.Selection.ApplyPropertyValue(Inline.TextDecorationsProperty, textDecorations);
            }
        }
        //đã check
        private void fontFamilyComboBox_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            if(fontSizeComboBox.SelectedItem!=null)
            {
                contentRichTextBox.Selection.ApplyPropertyValue(Inline.FontFamilyProperty, fontFamilyComboBox.SelectedItem);
            }
        }
        //đã check
        private void fontSizeComboBox_TextChanged(object sender, TextChangedEventArgs e)
        {
            contentRichTextBox.Selection.ApplyPropertyValue(Inline.FontSizeProperty, fontSizeComboBox.Text);
        }
        
        // chưa check
        private void SaveFileButton_Click(object sender, RoutedEventArgs e)
        {
            string rtfFile = System.IO.Path.Combine(Environment.CurrentDirectory, $"{viewModel.SelectedNote.Id}.rtf");
            viewModel.SelectedNote.FileLocation = rtfFile;

            using (FileStream fileStream = new FileStream(rtfFile, FileMode.Create))
            {
                TextRange range = new TextRange(contentRichTextBox.Document.ContentStart, contentRichTextBox.Document.ContentEnd);
                range.Save(fileStream, DataFormats.Rtf);
            }

            viewModel.UpdateSelectedNote();
        }
    }
}
 