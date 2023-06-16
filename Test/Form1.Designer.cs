namespace Test
{
    partial class TestForm
    {
        private System.ComponentModel.IContainer components = null;
        private System.Windows.Forms.Label questionLabel;
        private System.Windows.Forms.ProgressBar progressBar;
        private System.Windows.Forms.Button okButton;
        private System.Windows.Forms.RadioButton answerRadioButton1;
        private System.Windows.Forms.RadioButton answerRadioButton2;
        private System.Windows.Forms.RadioButton answerRadioButton3;

        /// <summary>
        /// Обязательная переменная конструктора.
        /// </summary>
        private void InitializeComponent()
        {
            questionLabel = new Label();
            progressBar = new ProgressBar();
            okButton = new Button();
            answerRadioButton1 = new RadioButton();
            answerRadioButton2 = new RadioButton();
            answerRadioButton3 = new RadioButton();
            SuspendLayout();
            // 
            // questionLabel
            // 
            questionLabel.AutoSize = true;
            questionLabel.Location = new Point(38, 56);
            questionLabel.Name = "questionLabel";
            questionLabel.Size = new Size(0, 15);
            questionLabel.TabIndex = 0;
            // 
            // progressBar
            // 
            progressBar.Location = new Point(50, 19);
            progressBar.Name = "progressBar";
            progressBar.Size = new Size(187, 13);
            progressBar.TabIndex = 2;
            // 
            // okButton
            // 
            okButton.Location = new Point(169, 184);
            okButton.Name = "okButton";
            okButton.Size = new Size(41, 32);
            okButton.TabIndex = 3;
            okButton.Text = "Ok";
            okButton.UseVisualStyleBackColor = true;
            okButton.Click += okButton_Click;
            // 
            // answerRadioButton1
            // 
            answerRadioButton1.AutoSize = true;
            answerRadioButton1.Location = new Point(41, 86);
            answerRadioButton1.Name = "answerRadioButton1";
            answerRadioButton1.Size = new Size(14, 13);
            answerRadioButton1.TabIndex = 4;
            answerRadioButton1.TabStop = true;
            answerRadioButton1.UseVisualStyleBackColor = true;
            // 
            // answerRadioButton2
            // 
            answerRadioButton2.AutoSize = true;
            answerRadioButton2.Location = new Point(41, 109);
            answerRadioButton2.Name = "answerRadioButton2";
            answerRadioButton2.Size = new Size(14, 13);
            answerRadioButton2.TabIndex = 4;
            answerRadioButton2.TabStop = true;
            answerRadioButton2.UseVisualStyleBackColor = true;
            // 
            // answerRadioButton3
            // 
            answerRadioButton3.AutoSize = true;
            answerRadioButton3.Location = new Point(41, 132);
            answerRadioButton3.Name = "answerRadioButton3";
            answerRadioButton3.Size = new Size(14, 13);
            answerRadioButton3.TabIndex = 4;
            answerRadioButton3.TabStop = true;
            answerRadioButton3.UseVisualStyleBackColor = true;
            // 
            // TestForm
            // 
            ClientSize = new Size(292, 261);
            Controls.Add(answerRadioButton3);
            Controls.Add(answerRadioButton2);
            Controls.Add(answerRadioButton1);
            Controls.Add(okButton);
            Controls.Add(progressBar);
            Controls.Add(questionLabel);
            Name = "TestForm";
            Load += TestForm_Load;
            ResumeLayout(false);
            PerformLayout();
        }
    }
}