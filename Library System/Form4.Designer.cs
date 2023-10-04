namespace Library_System
{
    partial class frmBorrow
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
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
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmBorrow));
            this.borrow_Fname = new System.Windows.Forms.TextBox();
            this.borrow_Lname = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.borrow_phoneNum = new System.Windows.Forms.TextBox();
            this.borrow_emailAdd = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.button1 = new System.Windows.Forms.Button();
            this.label5 = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // borrow_Fname
            // 
            this.borrow_Fname.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.borrow_Fname.Location = new System.Drawing.Point(402, 126);
            this.borrow_Fname.Name = "borrow_Fname";
            this.borrow_Fname.Size = new System.Drawing.Size(124, 13);
            this.borrow_Fname.TabIndex = 0;
            // 
            // borrow_Lname
            // 
            this.borrow_Lname.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.borrow_Lname.Location = new System.Drawing.Point(567, 126);
            this.borrow_Lname.Name = "borrow_Lname";
            this.borrow_Lname.Size = new System.Drawing.Size(122, 13);
            this.borrow_Lname.TabIndex = 1;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.BackColor = System.Drawing.Color.Transparent;
            this.label1.Location = new System.Drawing.Point(400, 99);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(57, 13);
            this.label1.TabIndex = 2;
            this.label1.Text = "First Name";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.BackColor = System.Drawing.Color.Transparent;
            this.label2.Location = new System.Drawing.Point(562, 99);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(58, 13);
            this.label2.TabIndex = 3;
            this.label2.Text = "Last Name";
            // 
            // borrow_phoneNum
            // 
            this.borrow_phoneNum.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.borrow_phoneNum.Location = new System.Drawing.Point(403, 194);
            this.borrow_phoneNum.Name = "borrow_phoneNum";
            this.borrow_phoneNum.Size = new System.Drawing.Size(123, 13);
            this.borrow_phoneNum.TabIndex = 4;
            // 
            // borrow_emailAdd
            // 
            this.borrow_emailAdd.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.borrow_emailAdd.Location = new System.Drawing.Point(403, 263);
            this.borrow_emailAdd.Name = "borrow_emailAdd";
            this.borrow_emailAdd.Size = new System.Drawing.Size(273, 13);
            this.borrow_emailAdd.TabIndex = 5;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.BackColor = System.Drawing.Color.Transparent;
            this.label3.Location = new System.Drawing.Point(400, 166);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(78, 13);
            this.label3.TabIndex = 6;
            this.label3.Text = "Phone Number";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.BackColor = System.Drawing.Color.Transparent;
            this.label4.Location = new System.Drawing.Point(400, 237);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(73, 13);
            this.label4.TabIndex = 7;
            this.label4.Text = "Email Address";
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(489, 305);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(103, 50);
            this.button1.TabIndex = 8;
            this.button1.Text = "Submit";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.BackColor = System.Drawing.Color.Transparent;
            this.label5.Font = new System.Drawing.Font("Microsoft Sans Serif", 18F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label5.Location = new System.Drawing.Point(418, 29);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(258, 29);
            this.label5.TabIndex = 9;
            this.label5.Text = "Borrower Information";
            // 
            // frmBorrow
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("$this.BackgroundImage")));
            this.ClientSize = new System.Drawing.Size(710, 367);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.borrow_emailAdd);
            this.Controls.Add(this.borrow_phoneNum);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.borrow_Lname);
            this.Controls.Add(this.borrow_Fname);
            this.Name = "frmBorrow";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Borrower";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TextBox borrow_Fname;
        private System.Windows.Forms.TextBox borrow_Lname;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox borrow_phoneNum;
        private System.Windows.Forms.TextBox borrow_emailAdd;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.Label label5;
    }
}