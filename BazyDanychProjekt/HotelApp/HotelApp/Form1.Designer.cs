namespace HotelApp
{
    partial class Form1
    {
        /// <summary>
        ///  Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        ///  Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        ///  Required method for Designer support - do not modify
        ///  the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            button1 = new Button();
            listBox1 = new ListBox();
            startDateText = new TextBox();
            endDateText = new TextBox();
            button2 = new Button();
            label1 = new Label();
            listBox2 = new ListBox();
            button3 = new Button();
            bookingIdText = new TextBox();
            label2 = new Label();
            customerIDTEXT = new TextBox();
            roomIdText = new TextBox();
            rentDateText = new TextBox();
            rentDurationText = new TextBox();
            countText = new TextBox();
            label3 = new Label();
            addbookingbutton = new Button();
            label4 = new Label();
            label5 = new Label();
            label6 = new Label();
            label7 = new Label();
            label8 = new Label();
            SuspendLayout();
            // 
            // button1
            // 
            button1.Location = new Point(153, 470);
            button1.Name = "button1";
            button1.Size = new Size(131, 64);
            button1.TabIndex = 0;
            button1.Text = "Get ALL bookings";
            button1.UseVisualStyleBackColor = true;
            button1.Click += button1_Click;
            // 
            // listBox1
            // 
            listBox1.FormattingEnabled = true;
            listBox1.ItemHeight = 15;
            listBox1.Location = new Point(16, 10);
            listBox1.Name = "listBox1";
            listBox1.Size = new Size(394, 439);
            listBox1.TabIndex = 1;
            // 
            // startDateText
            // 
            startDateText.Location = new Point(539, 415);
            startDateText.Name = "startDateText";
            startDateText.Size = new Size(126, 23);
            startDateText.TabIndex = 2;
            // 
            // endDateText
            // 
            endDateText.Location = new Point(539, 446);
            endDateText.Name = "endDateText";
            endDateText.Size = new Size(126, 23);
            endDateText.TabIndex = 3;
            // 
            // button2
            // 
            button2.Location = new Point(553, 483);
            button2.Name = "button2";
            button2.Size = new Size(102, 41);
            button2.TabIndex = 4;
            button2.Text = "Get Free Rooms";
            button2.UseVisualStyleBackColor = true;
            button2.Click += button2_Click;
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Location = new Point(552, 397);
            label1.Name = "label1";
            label1.Size = new Size(103, 15);
            label1.TabIndex = 5;
            label1.Text = "Start and End date";
            // 
            // listBox2
            // 
            listBox2.FormattingEnabled = true;
            listBox2.ItemHeight = 15;
            listBox2.Location = new Point(453, 12);
            listBox2.Name = "listBox2";
            listBox2.Size = new Size(297, 364);
            listBox2.TabIndex = 6;
            // 
            // button3
            // 
            button3.Location = new Point(808, 475);
            button3.Name = "button3";
            button3.Size = new Size(105, 46);
            button3.TabIndex = 7;
            button3.Text = "Remove Booking by ID";
            button3.UseVisualStyleBackColor = true;
            button3.Click += button3_Click;
            // 
            // bookingIdText
            // 
            bookingIdText.Location = new Point(808, 436);
            bookingIdText.Name = "bookingIdText";
            bookingIdText.Size = new Size(105, 23);
            bookingIdText.TabIndex = 8;
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Location = new Point(824, 418);
            label2.Name = "label2";
            label2.Size = new Size(65, 15);
            label2.TabIndex = 9;
            label2.Text = "Booking ID";
            // 
            // customerIDTEXT
            // 
            customerIDTEXT.Location = new Point(805, 71);
            customerIDTEXT.Name = "customerIDTEXT";
            customerIDTEXT.Size = new Size(124, 23);
            customerIDTEXT.TabIndex = 10;
            // 
            // roomIdText
            // 
            roomIdText.Location = new Point(805, 110);
            roomIdText.Name = "roomIdText";
            roomIdText.Size = new Size(124, 23);
            roomIdText.TabIndex = 11;
            // 
            // rentDateText
            // 
            rentDateText.Location = new Point(805, 153);
            rentDateText.Name = "rentDateText";
            rentDateText.Size = new Size(124, 23);
            rentDateText.TabIndex = 12;
            // 
            // rentDurationText
            // 
            rentDurationText.Location = new Point(805, 193);
            rentDurationText.Name = "rentDurationText";
            rentDurationText.Size = new Size(124, 23);
            rentDurationText.TabIndex = 13;
            // 
            // countText
            // 
            countText.Location = new Point(805, 231);
            countText.Name = "countText";
            countText.Size = new Size(124, 23);
            countText.TabIndex = 14;
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.Font = new Font("Segoe UI", 9F, FontStyle.Bold, GraphicsUnit.Point, 238);
            label3.Location = new Point(824, 27);
            label3.Name = "label3";
            label3.Size = new Size(92, 15);
            label3.TabIndex = 15;
            label3.Text = "ADD BOOKING";
            // 
            // addbookingbutton
            // 
            addbookingbutton.Location = new Point(814, 276);
            addbookingbutton.Name = "addbookingbutton";
            addbookingbutton.Size = new Size(105, 39);
            addbookingbutton.TabIndex = 16;
            addbookingbutton.Text = "ADD";
            addbookingbutton.UseVisualStyleBackColor = true;
            addbookingbutton.Click += addbookingbutton_Click;
            // 
            // label4
            // 
            label4.AutoSize = true;
            label4.Location = new Point(788, 53);
            label4.Name = "label4";
            label4.Size = new Size(78, 15);
            label4.TabIndex = 17;
            label4.Text = "Customer_ID:";
            // 
            // label5
            // 
            label5.AutoSize = true;
            label5.Location = new Point(788, 97);
            label5.Name = "label5";
            label5.Size = new Size(58, 15);
            label5.TabIndex = 18;
            label5.Text = "Room_ID:";
            // 
            // label6
            // 
            label6.AutoSize = true;
            label6.Location = new Point(788, 135);
            label6.Name = "label6";
            label6.Size = new Size(128, 15);
            label6.TabIndex = 19;
            label6.Text = "rentDate (rrrr-mm-dd):";
            // 
            // label7
            // 
            label7.AutoSize = true;
            label7.Location = new Point(788, 175);
            label7.Name = "label7";
            label7.Size = new Size(127, 15);
            label7.TabIndex = 20;
            label7.Text = "rent duration (in days):";
            // 
            // label8
            // 
            label8.AutoSize = true;
            label8.Location = new Point(788, 219);
            label8.Name = "label8";
            label8.Size = new Size(84, 15);
            label8.TabIndex = 21;
            label8.Text = "Person_Count:";
            // 
            // Form1
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(984, 546);
            Controls.Add(label8);
            Controls.Add(label7);
            Controls.Add(label6);
            Controls.Add(label5);
            Controls.Add(label4);
            Controls.Add(addbookingbutton);
            Controls.Add(label3);
            Controls.Add(countText);
            Controls.Add(rentDurationText);
            Controls.Add(rentDateText);
            Controls.Add(roomIdText);
            Controls.Add(customerIDTEXT);
            Controls.Add(label2);
            Controls.Add(bookingIdText);
            Controls.Add(button3);
            Controls.Add(listBox2);
            Controls.Add(label1);
            Controls.Add(button2);
            Controls.Add(endDateText);
            Controls.Add(startDateText);
            Controls.Add(listBox1);
            Controls.Add(button1);
            Name = "Form1";
            Text = "Form1";
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Button button1;
        private ListBox listBox1;
        private TextBox startDateText;
        private TextBox endDateText;
        private Button button2;
        private Label label1;
        private ListBox listBox2;
        private Button button3;
        private TextBox bookingIdText;
        private Label label2;
        private TextBox customerIDTEXT;
        private TextBox roomIdText;
        private TextBox rentDateText;
        private TextBox rentDurationText;
        private TextBox countText;
        private Label label3;
        private Button addbookingbutton;
        private Label label4;
        private Label label5;
        private Label label6;
        private Label label7;
        private Label label8;
    }
}
