
namespace CINEFLICKS
{
    partial class frmSelectActorPopUp
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmSelectActorPopUp));
            Bunifu.UI.WinForms.BunifuButton.BunifuButton.BorderEdges borderEdges1 = new Bunifu.UI.WinForms.BunifuButton.BunifuButton.BorderEdges();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle1 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle2 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle3 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle4 = new System.Windows.Forms.DataGridViewCellStyle();
            Bunifu.UI.WinForms.BunifuButton.BunifuButton.BorderEdges borderEdges2 = new Bunifu.UI.WinForms.BunifuButton.BunifuButton.BorderEdges();
            Bunifu.UI.WinForms.BunifuTextBox.StateProperties stateProperties1 = new Bunifu.UI.WinForms.BunifuTextBox.StateProperties();
            Bunifu.UI.WinForms.BunifuTextBox.StateProperties stateProperties2 = new Bunifu.UI.WinForms.BunifuTextBox.StateProperties();
            Bunifu.UI.WinForms.BunifuTextBox.StateProperties stateProperties3 = new Bunifu.UI.WinForms.BunifuTextBox.StateProperties();
            Bunifu.UI.WinForms.BunifuTextBox.StateProperties stateProperties4 = new Bunifu.UI.WinForms.BunifuTextBox.StateProperties();
            this.btnActAdd = new Bunifu.UI.WinForms.BunifuButton.BunifuButton();
            this.dgvSelectActor = new Bunifu.UI.WinForms.BunifuDataGridView();
            this.colGenSelect = new System.Windows.Forms.DataGridViewCheckBoxColumn();
            this.btnActCancel = new Bunifu.UI.WinForms.BunifuButton.BunifuButton();
            this.txtActSearch = new Bunifu.UI.WinForms.BunifuTextBox();
            ((System.ComponentModel.ISupportInitialize)(this.dgvSelectActor)).BeginInit();
            this.SuspendLayout();
            // 
            // btnActAdd
            // 
            this.btnActAdd.AllowAnimations = true;
            this.btnActAdd.AllowMouseEffects = true;
            this.btnActAdd.AllowToggling = false;
            this.btnActAdd.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.btnActAdd.AnimationSpeed = 200;
            this.btnActAdd.AutoGenerateColors = false;
            this.btnActAdd.AutoRoundBorders = false;
            this.btnActAdd.AutoSizeLeftIcon = true;
            this.btnActAdd.AutoSizeRightIcon = true;
            this.btnActAdd.BackColor = System.Drawing.Color.Transparent;
            this.btnActAdd.BackColor1 = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(0)))), ((int)(((byte)(110)))));
            this.btnActAdd.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("btnActAdd.BackgroundImage")));
            this.btnActAdd.BorderStyle = Bunifu.UI.WinForms.BunifuButton.BunifuButton.BorderStyles.Solid;
            this.btnActAdd.ButtonText = "Add";
            this.btnActAdd.ButtonTextMarginLeft = 0;
            this.btnActAdd.ColorContrastOnClick = 45;
            this.btnActAdd.ColorContrastOnHover = 45;
            this.btnActAdd.Cursor = System.Windows.Forms.Cursors.Hand;
            borderEdges1.BottomLeft = true;
            borderEdges1.BottomRight = true;
            borderEdges1.TopLeft = true;
            borderEdges1.TopRight = true;
            this.btnActAdd.CustomizableEdges = borderEdges1;
            this.btnActAdd.DialogResult = System.Windows.Forms.DialogResult.None;
            this.btnActAdd.DisabledBorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(191)))), ((int)(((byte)(191)))), ((int)(((byte)(191)))));
            this.btnActAdd.DisabledFillColor = System.Drawing.Color.FromArgb(((int)(((byte)(204)))), ((int)(((byte)(204)))), ((int)(((byte)(204)))));
            this.btnActAdd.DisabledForecolor = System.Drawing.Color.FromArgb(((int)(((byte)(168)))), ((int)(((byte)(160)))), ((int)(((byte)(168)))));
            this.btnActAdd.FocusState = Bunifu.UI.WinForms.BunifuButton.BunifuButton.ButtonStates.Pressed;
            this.btnActAdd.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Bold);
            this.btnActAdd.ForeColor = System.Drawing.Color.White;
            this.btnActAdd.IconLeftAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnActAdd.IconLeftCursor = System.Windows.Forms.Cursors.Default;
            this.btnActAdd.IconLeftPadding = new System.Windows.Forms.Padding(8, 3, 3, 3);
            this.btnActAdd.IconMarginLeft = 11;
            this.btnActAdd.IconPadding = 5;
            this.btnActAdd.IconRightAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.btnActAdd.IconRightCursor = System.Windows.Forms.Cursors.Default;
            this.btnActAdd.IconRightPadding = new System.Windows.Forms.Padding(3, 3, 7, 3);
            this.btnActAdd.IconSize = 25;
            this.btnActAdd.IdleBorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(0)))), ((int)(((byte)(110)))));
            this.btnActAdd.IdleBorderRadius = 10;
            this.btnActAdd.IdleBorderThickness = 1;
            this.btnActAdd.IdleFillColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(0)))), ((int)(((byte)(110)))));
            this.btnActAdd.IdleIconLeftImage = global::CINEFLICKS.Properties.Resources.add_60px;
            this.btnActAdd.IdleIconRightImage = null;
            this.btnActAdd.IndicateFocus = false;
            this.btnActAdd.Location = new System.Drawing.Point(332, 20);
            this.btnActAdd.Margin = new System.Windows.Forms.Padding(0);
            this.btnActAdd.Name = "btnActAdd";
            this.btnActAdd.OnDisabledState.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(191)))), ((int)(((byte)(191)))), ((int)(((byte)(191)))));
            this.btnActAdd.OnDisabledState.BorderRadius = 10;
            this.btnActAdd.OnDisabledState.BorderStyle = Bunifu.UI.WinForms.BunifuButton.BunifuButton.BorderStyles.Solid;
            this.btnActAdd.OnDisabledState.BorderThickness = 1;
            this.btnActAdd.OnDisabledState.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(204)))), ((int)(((byte)(204)))), ((int)(((byte)(204)))));
            this.btnActAdd.OnDisabledState.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(168)))), ((int)(((byte)(160)))), ((int)(((byte)(168)))));
            this.btnActAdd.OnDisabledState.IconLeftImage = null;
            this.btnActAdd.OnDisabledState.IconRightImage = null;
            this.btnActAdd.onHoverState.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(225)))), ((int)(((byte)(3)))), ((int)(((byte)(99)))));
            this.btnActAdd.onHoverState.BorderRadius = 10;
            this.btnActAdd.onHoverState.BorderStyle = Bunifu.UI.WinForms.BunifuButton.BunifuButton.BorderStyles.Solid;
            this.btnActAdd.onHoverState.BorderThickness = 1;
            this.btnActAdd.onHoverState.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(225)))), ((int)(((byte)(3)))), ((int)(((byte)(99)))));
            this.btnActAdd.onHoverState.ForeColor = System.Drawing.Color.White;
            this.btnActAdd.onHoverState.IconLeftImage = null;
            this.btnActAdd.onHoverState.IconRightImage = null;
            this.btnActAdd.OnIdleState.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(0)))), ((int)(((byte)(110)))));
            this.btnActAdd.OnIdleState.BorderRadius = 10;
            this.btnActAdd.OnIdleState.BorderStyle = Bunifu.UI.WinForms.BunifuButton.BunifuButton.BorderStyles.Solid;
            this.btnActAdd.OnIdleState.BorderThickness = 1;
            this.btnActAdd.OnIdleState.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(0)))), ((int)(((byte)(110)))));
            this.btnActAdd.OnIdleState.ForeColor = System.Drawing.Color.White;
            this.btnActAdd.OnIdleState.IconLeftImage = global::CINEFLICKS.Properties.Resources.add_60px;
            this.btnActAdd.OnIdleState.IconRightImage = null;
            this.btnActAdd.OnPressedState.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(0)))), ((int)(((byte)(110)))));
            this.btnActAdd.OnPressedState.BorderRadius = 10;
            this.btnActAdd.OnPressedState.BorderStyle = Bunifu.UI.WinForms.BunifuButton.BunifuButton.BorderStyles.Solid;
            this.btnActAdd.OnPressedState.BorderThickness = 1;
            this.btnActAdd.OnPressedState.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(0)))), ((int)(((byte)(110)))));
            this.btnActAdd.OnPressedState.ForeColor = System.Drawing.Color.White;
            this.btnActAdd.OnPressedState.IconLeftImage = null;
            this.btnActAdd.OnPressedState.IconRightImage = null;
            this.btnActAdd.Size = new System.Drawing.Size(82, 30);
            this.btnActAdd.TabIndex = 15;
            this.btnActAdd.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.btnActAdd.TextAlignment = System.Windows.Forms.HorizontalAlignment.Center;
            this.btnActAdd.TextMarginLeft = 0;
            this.btnActAdd.TextPadding = new System.Windows.Forms.Padding(0, 0, 5, 0);
            this.btnActAdd.UseDefaultRadiusAndThickness = true;
            this.btnActAdd.Click += new System.EventHandler(this.btnActAdd_Click);
            // 
            // dgvSelectActor
            // 
            this.dgvSelectActor.AllowCustomTheming = true;
            this.dgvSelectActor.AllowUserToAddRows = false;
            this.dgvSelectActor.AllowUserToDeleteRows = false;
            dataGridViewCellStyle1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(248)))), ((int)(((byte)(251)))), ((int)(((byte)(255)))));
            dataGridViewCellStyle1.ForeColor = System.Drawing.Color.Black;
            this.dgvSelectActor.AlternatingRowsDefaultCellStyle = dataGridViewCellStyle1;
            this.dgvSelectActor.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left)));
            this.dgvSelectActor.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dgvSelectActor.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.dgvSelectActor.CellBorderStyle = System.Windows.Forms.DataGridViewCellBorderStyle.SingleHorizontal;
            this.dgvSelectActor.ColumnHeadersBorderStyle = System.Windows.Forms.DataGridViewHeaderBorderStyle.Single;
            dataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle2.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(44)))), ((int)(((byte)(120)))), ((int)(((byte)(247)))));
            dataGridViewCellStyle2.Font = new System.Drawing.Font("Segoe UI Semibold", 11.75F, System.Drawing.FontStyle.Bold);
            dataGridViewCellStyle2.ForeColor = System.Drawing.Color.White;
            dataGridViewCellStyle2.SelectionBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(24)))), ((int)(((byte)(115)))), ((int)(((byte)(204)))));
            dataGridViewCellStyle2.SelectionForeColor = System.Drawing.Color.White;
            dataGridViewCellStyle2.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dgvSelectActor.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle2;
            this.dgvSelectActor.ColumnHeadersHeight = 40;
            this.dgvSelectActor.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.colGenSelect});
            this.dgvSelectActor.CurrentTheme.AlternatingRowsStyle.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(248)))), ((int)(((byte)(251)))), ((int)(((byte)(255)))));
            this.dgvSelectActor.CurrentTheme.AlternatingRowsStyle.Font = new System.Drawing.Font("Segoe UI Semibold", 9.75F, System.Drawing.FontStyle.Bold);
            this.dgvSelectActor.CurrentTheme.AlternatingRowsStyle.ForeColor = System.Drawing.Color.Black;
            this.dgvSelectActor.CurrentTheme.AlternatingRowsStyle.SelectionBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(210)))), ((int)(((byte)(232)))), ((int)(((byte)(255)))));
            this.dgvSelectActor.CurrentTheme.AlternatingRowsStyle.SelectionForeColor = System.Drawing.Color.Black;
            this.dgvSelectActor.CurrentTheme.BackColor = System.Drawing.Color.White;
            this.dgvSelectActor.CurrentTheme.GridColor = System.Drawing.Color.FromArgb(((int)(((byte)(221)))), ((int)(((byte)(238)))), ((int)(((byte)(255)))));
            this.dgvSelectActor.CurrentTheme.HeaderStyle.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(44)))), ((int)(((byte)(120)))), ((int)(((byte)(247)))));
            this.dgvSelectActor.CurrentTheme.HeaderStyle.Font = new System.Drawing.Font("Segoe UI Semibold", 11.75F, System.Drawing.FontStyle.Bold);
            this.dgvSelectActor.CurrentTheme.HeaderStyle.ForeColor = System.Drawing.Color.White;
            this.dgvSelectActor.CurrentTheme.HeaderStyle.SelectionBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(24)))), ((int)(((byte)(115)))), ((int)(((byte)(204)))));
            this.dgvSelectActor.CurrentTheme.HeaderStyle.SelectionForeColor = System.Drawing.Color.White;
            this.dgvSelectActor.CurrentTheme.Name = null;
            this.dgvSelectActor.CurrentTheme.RowsStyle.BackColor = System.Drawing.Color.White;
            this.dgvSelectActor.CurrentTheme.RowsStyle.Font = new System.Drawing.Font("Segoe UI Semibold", 9.75F, System.Drawing.FontStyle.Bold);
            this.dgvSelectActor.CurrentTheme.RowsStyle.ForeColor = System.Drawing.Color.Black;
            this.dgvSelectActor.CurrentTheme.RowsStyle.SelectionBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(210)))), ((int)(((byte)(232)))), ((int)(((byte)(255)))));
            this.dgvSelectActor.CurrentTheme.RowsStyle.SelectionForeColor = System.Drawing.Color.Black;
            dataGridViewCellStyle3.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle3.BackColor = System.Drawing.Color.White;
            dataGridViewCellStyle3.Font = new System.Drawing.Font("Segoe UI Semibold", 9.75F, System.Drawing.FontStyle.Bold);
            dataGridViewCellStyle3.ForeColor = System.Drawing.Color.Black;
            dataGridViewCellStyle3.SelectionBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(210)))), ((int)(((byte)(232)))), ((int)(((byte)(255)))));
            dataGridViewCellStyle3.SelectionForeColor = System.Drawing.Color.Black;
            dataGridViewCellStyle3.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
            this.dgvSelectActor.DefaultCellStyle = dataGridViewCellStyle3;
            this.dgvSelectActor.EnableHeadersVisualStyles = false;
            this.dgvSelectActor.GridColor = System.Drawing.Color.FromArgb(((int)(((byte)(221)))), ((int)(((byte)(238)))), ((int)(((byte)(255)))));
            this.dgvSelectActor.HeaderBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(44)))), ((int)(((byte)(120)))), ((int)(((byte)(247)))));
            this.dgvSelectActor.HeaderBgColor = System.Drawing.Color.Empty;
            this.dgvSelectActor.HeaderForeColor = System.Drawing.Color.White;
            this.dgvSelectActor.Location = new System.Drawing.Point(22, 65);
            this.dgvSelectActor.Name = "dgvSelectActor";
            this.dgvSelectActor.RowHeadersBorderStyle = System.Windows.Forms.DataGridViewHeaderBorderStyle.Single;
            dataGridViewCellStyle4.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle4.BackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle4.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle4.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle4.NullValue = null;
            dataGridViewCellStyle4.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle4.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle4.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dgvSelectActor.RowHeadersDefaultCellStyle = dataGridViewCellStyle4;
            this.dgvSelectActor.RowHeadersVisible = false;
            this.dgvSelectActor.RowTemplate.Height = 40;
            this.dgvSelectActor.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgvSelectActor.Size = new System.Drawing.Size(287, 310);
            this.dgvSelectActor.TabIndex = 33;
            this.dgvSelectActor.Theme = Bunifu.UI.WinForms.BunifuDataGridView.PresetThemes.Light;
            // 
            // colGenSelect
            // 
            this.colGenSelect.FalseValue = "false";
            this.colGenSelect.HeaderText = "Select";
            this.colGenSelect.Name = "colGenSelect";
            this.colGenSelect.TrueValue = "true";
            // 
            // btnActCancel
            // 
            this.btnActCancel.AllowAnimations = true;
            this.btnActCancel.AllowMouseEffects = true;
            this.btnActCancel.AllowToggling = false;
            this.btnActCancel.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.btnActCancel.AnimationSpeed = 200;
            this.btnActCancel.AutoGenerateColors = false;
            this.btnActCancel.AutoRoundBorders = false;
            this.btnActCancel.AutoSizeLeftIcon = true;
            this.btnActCancel.AutoSizeRightIcon = true;
            this.btnActCancel.BackColor = System.Drawing.Color.Transparent;
            this.btnActCancel.BackColor1 = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(154)))), ((int)(((byte)(0)))));
            this.btnActCancel.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("btnActCancel.BackgroundImage")));
            this.btnActCancel.BorderStyle = Bunifu.UI.WinForms.BunifuButton.BunifuButton.BorderStyles.Solid;
            this.btnActCancel.ButtonText = "Cancel";
            this.btnActCancel.ButtonTextMarginLeft = 0;
            this.btnActCancel.ColorContrastOnClick = 45;
            this.btnActCancel.ColorContrastOnHover = 45;
            this.btnActCancel.Cursor = System.Windows.Forms.Cursors.Hand;
            borderEdges2.BottomLeft = true;
            borderEdges2.BottomRight = true;
            borderEdges2.TopLeft = true;
            borderEdges2.TopRight = true;
            this.btnActCancel.CustomizableEdges = borderEdges2;
            this.btnActCancel.DialogResult = System.Windows.Forms.DialogResult.None;
            this.btnActCancel.DisabledBorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(191)))), ((int)(((byte)(191)))), ((int)(((byte)(191)))));
            this.btnActCancel.DisabledFillColor = System.Drawing.Color.FromArgb(((int)(((byte)(204)))), ((int)(((byte)(204)))), ((int)(((byte)(204)))));
            this.btnActCancel.DisabledForecolor = System.Drawing.Color.FromArgb(((int)(((byte)(168)))), ((int)(((byte)(160)))), ((int)(((byte)(168)))));
            this.btnActCancel.FocusState = Bunifu.UI.WinForms.BunifuButton.BunifuButton.ButtonStates.Pressed;
            this.btnActCancel.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Bold);
            this.btnActCancel.ForeColor = System.Drawing.Color.White;
            this.btnActCancel.IconLeftAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnActCancel.IconLeftCursor = System.Windows.Forms.Cursors.Default;
            this.btnActCancel.IconLeftPadding = new System.Windows.Forms.Padding(11, 3, 3, 3);
            this.btnActCancel.IconMarginLeft = 11;
            this.btnActCancel.IconPadding = 7;
            this.btnActCancel.IconRightAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.btnActCancel.IconRightCursor = System.Windows.Forms.Cursors.Default;
            this.btnActCancel.IconRightPadding = new System.Windows.Forms.Padding(3, 3, 7, 3);
            this.btnActCancel.IconSize = 25;
            this.btnActCancel.IdleBorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(154)))), ((int)(((byte)(0)))));
            this.btnActCancel.IdleBorderRadius = 10;
            this.btnActCancel.IdleBorderThickness = 1;
            this.btnActCancel.IdleFillColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(154)))), ((int)(((byte)(0)))));
            this.btnActCancel.IdleIconLeftImage = global::CINEFLICKS.Properties.Resources.delete_60px;
            this.btnActCancel.IdleIconRightImage = null;
            this.btnActCancel.IndicateFocus = false;
            this.btnActCancel.Location = new System.Drawing.Point(332, 65);
            this.btnActCancel.Margin = new System.Windows.Forms.Padding(0);
            this.btnActCancel.Name = "btnActCancel";
            this.btnActCancel.OnDisabledState.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(191)))), ((int)(((byte)(191)))), ((int)(((byte)(191)))));
            this.btnActCancel.OnDisabledState.BorderRadius = 10;
            this.btnActCancel.OnDisabledState.BorderStyle = Bunifu.UI.WinForms.BunifuButton.BunifuButton.BorderStyles.Solid;
            this.btnActCancel.OnDisabledState.BorderThickness = 1;
            this.btnActCancel.OnDisabledState.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(204)))), ((int)(((byte)(204)))), ((int)(((byte)(204)))));
            this.btnActCancel.OnDisabledState.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(168)))), ((int)(((byte)(160)))), ((int)(((byte)(168)))));
            this.btnActCancel.OnDisabledState.IconLeftImage = null;
            this.btnActCancel.OnDisabledState.IconRightImage = null;
            this.btnActCancel.onHoverState.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(232)))), ((int)(((byte)(141)))), ((int)(((byte)(3)))));
            this.btnActCancel.onHoverState.BorderRadius = 10;
            this.btnActCancel.onHoverState.BorderStyle = Bunifu.UI.WinForms.BunifuButton.BunifuButton.BorderStyles.Solid;
            this.btnActCancel.onHoverState.BorderThickness = 1;
            this.btnActCancel.onHoverState.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(232)))), ((int)(((byte)(141)))), ((int)(((byte)(3)))));
            this.btnActCancel.onHoverState.ForeColor = System.Drawing.Color.White;
            this.btnActCancel.onHoverState.IconLeftImage = null;
            this.btnActCancel.onHoverState.IconRightImage = null;
            this.btnActCancel.OnIdleState.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(154)))), ((int)(((byte)(0)))));
            this.btnActCancel.OnIdleState.BorderRadius = 10;
            this.btnActCancel.OnIdleState.BorderStyle = Bunifu.UI.WinForms.BunifuButton.BunifuButton.BorderStyles.Solid;
            this.btnActCancel.OnIdleState.BorderThickness = 1;
            this.btnActCancel.OnIdleState.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(154)))), ((int)(((byte)(0)))));
            this.btnActCancel.OnIdleState.ForeColor = System.Drawing.Color.White;
            this.btnActCancel.OnIdleState.IconLeftImage = global::CINEFLICKS.Properties.Resources.delete_60px;
            this.btnActCancel.OnIdleState.IconRightImage = null;
            this.btnActCancel.OnPressedState.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(154)))), ((int)(((byte)(0)))));
            this.btnActCancel.OnPressedState.BorderRadius = 10;
            this.btnActCancel.OnPressedState.BorderStyle = Bunifu.UI.WinForms.BunifuButton.BunifuButton.BorderStyles.Solid;
            this.btnActCancel.OnPressedState.BorderThickness = 1;
            this.btnActCancel.OnPressedState.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(154)))), ((int)(((byte)(0)))));
            this.btnActCancel.OnPressedState.ForeColor = System.Drawing.Color.White;
            this.btnActCancel.OnPressedState.IconLeftImage = null;
            this.btnActCancel.OnPressedState.IconRightImage = null;
            this.btnActCancel.Size = new System.Drawing.Size(99, 30);
            this.btnActCancel.TabIndex = 34;
            this.btnActCancel.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.btnActCancel.TextAlignment = System.Windows.Forms.HorizontalAlignment.Center;
            this.btnActCancel.TextMarginLeft = 0;
            this.btnActCancel.TextPadding = new System.Windows.Forms.Padding(0, 0, 5, 0);
            this.btnActCancel.UseDefaultRadiusAndThickness = true;
            this.btnActCancel.Click += new System.EventHandler(this.btnActCancel_Click);
            // 
            // txtActSearch
            // 
            this.txtActSearch.AcceptsReturn = false;
            this.txtActSearch.AcceptsTab = false;
            this.txtActSearch.AnimationSpeed = 200;
            this.txtActSearch.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.None;
            this.txtActSearch.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.None;
            this.txtActSearch.AutoSize = true;
            this.txtActSearch.BackColor = System.Drawing.Color.Transparent;
            this.txtActSearch.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("txtActSearch.BackgroundImage")));
            this.txtActSearch.BorderColorActive = System.Drawing.Color.DodgerBlue;
            this.txtActSearch.BorderColorDisabled = System.Drawing.Color.FromArgb(((int)(((byte)(204)))), ((int)(((byte)(204)))), ((int)(((byte)(204)))));
            this.txtActSearch.BorderColorHover = System.Drawing.Color.FromArgb(((int)(((byte)(105)))), ((int)(((byte)(181)))), ((int)(((byte)(255)))));
            this.txtActSearch.BorderColorIdle = System.Drawing.Color.Silver;
            this.txtActSearch.BorderRadius = 10;
            this.txtActSearch.BorderThickness = 2;
            this.txtActSearch.CharacterCasing = System.Windows.Forms.CharacterCasing.Normal;
            this.txtActSearch.Cursor = System.Windows.Forms.Cursors.IBeam;
            this.txtActSearch.DefaultFont = new System.Drawing.Font("Segoe UI", 10F);
            this.txtActSearch.DefaultText = "";
            this.txtActSearch.FillColor = System.Drawing.Color.White;
            this.txtActSearch.HideSelection = true;
            this.txtActSearch.IconLeft = null;
            this.txtActSearch.IconLeftCursor = System.Windows.Forms.Cursors.IBeam;
            this.txtActSearch.IconPadding = 10;
            this.txtActSearch.IconRight = null;
            this.txtActSearch.IconRightCursor = System.Windows.Forms.Cursors.IBeam;
            this.txtActSearch.Lines = new string[0];
            this.txtActSearch.Location = new System.Drawing.Point(22, 20);
            this.txtActSearch.MaxLength = 32767;
            this.txtActSearch.MinimumSize = new System.Drawing.Size(1, 1);
            this.txtActSearch.Modified = false;
            this.txtActSearch.Multiline = false;
            this.txtActSearch.Name = "txtActSearch";
            stateProperties1.BorderColor = System.Drawing.Color.DodgerBlue;
            stateProperties1.FillColor = System.Drawing.Color.Empty;
            stateProperties1.ForeColor = System.Drawing.Color.Empty;
            stateProperties1.PlaceholderForeColor = System.Drawing.Color.Empty;
            this.txtActSearch.OnActiveState = stateProperties1;
            stateProperties2.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(204)))), ((int)(((byte)(204)))), ((int)(((byte)(204)))));
            stateProperties2.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(240)))), ((int)(((byte)(240)))), ((int)(((byte)(240)))));
            stateProperties2.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(109)))), ((int)(((byte)(109)))), ((int)(((byte)(109)))));
            stateProperties2.PlaceholderForeColor = System.Drawing.Color.DarkGray;
            this.txtActSearch.OnDisabledState = stateProperties2;
            stateProperties3.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(105)))), ((int)(((byte)(181)))), ((int)(((byte)(255)))));
            stateProperties3.FillColor = System.Drawing.Color.Empty;
            stateProperties3.ForeColor = System.Drawing.Color.Empty;
            stateProperties3.PlaceholderForeColor = System.Drawing.Color.Empty;
            this.txtActSearch.OnHoverState = stateProperties3;
            stateProperties4.BorderColor = System.Drawing.Color.Silver;
            stateProperties4.FillColor = System.Drawing.Color.White;
            stateProperties4.ForeColor = System.Drawing.Color.Empty;
            stateProperties4.PlaceholderForeColor = System.Drawing.Color.Empty;
            this.txtActSearch.OnIdleState = stateProperties4;
            this.txtActSearch.Padding = new System.Windows.Forms.Padding(3);
            this.txtActSearch.PasswordChar = '\0';
            this.txtActSearch.PlaceholderForeColor = System.Drawing.Color.Gray;
            this.txtActSearch.PlaceholderText = "Search...";
            this.txtActSearch.ReadOnly = false;
            this.txtActSearch.ScrollBars = System.Windows.Forms.ScrollBars.None;
            this.txtActSearch.SelectedText = "";
            this.txtActSearch.SelectionLength = 0;
            this.txtActSearch.SelectionStart = 0;
            this.txtActSearch.ShortcutsEnabled = true;
            this.txtActSearch.Size = new System.Drawing.Size(287, 30);
            this.txtActSearch.Style = Bunifu.UI.WinForms.BunifuTextBox._Style.Bunifu;
            this.txtActSearch.TabIndex = 35;
            this.txtActSearch.TextAlign = System.Windows.Forms.HorizontalAlignment.Left;
            this.txtActSearch.TextMarginBottom = 0;
            this.txtActSearch.TextMarginLeft = 0;
            this.txtActSearch.TextMarginTop = 0;
            this.txtActSearch.TextPlaceholder = "Search...";
            this.txtActSearch.UseSystemPasswordChar = false;
            this.txtActSearch.WordWrap = true;
            this.txtActSearch.TextChange += new System.EventHandler(this.txtActSearch_TextChange);
            // 
            // frmSelectActorPopUp
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(9)))), ((int)(((byte)(12)))), ((int)(((byte)(40)))));
            this.ClientSize = new System.Drawing.Size(447, 401);
            this.Controls.Add(this.txtActSearch);
            this.Controls.Add(this.btnActCancel);
            this.Controls.Add(this.dgvSelectActor);
            this.Controls.Add(this.btnActAdd);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Name = "frmSelectActorPopUp";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Select Actors - CINEFLICKS";
            this.Load += new System.EventHandler(this.frmSelectActorPopUp_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dgvSelectActor)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private Bunifu.UI.WinForms.BunifuButton.BunifuButton btnActAdd;
        private Bunifu.UI.WinForms.BunifuDataGridView dgvSelectActor;
        private Bunifu.UI.WinForms.BunifuButton.BunifuButton btnActCancel;
        private System.Windows.Forms.DataGridViewCheckBoxColumn colGenSelect;
        private Bunifu.UI.WinForms.BunifuTextBox txtActSearch;
    }
}