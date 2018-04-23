using System;
using System.Collections;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

using DevExpress.XtraGrid;
using DevExpress.XtraGrid.Views.Base;
using DevExpress.XtraGrid.Views.Grid;
using DevExpress.XtraGrid.Views.Base.ViewInfo;
using DevExpress.XtraGrid.Views.Grid.ViewInfo;
using DevExpress.XtraGrid.Registrator;
using DevExpress.XtraGrid.Columns;
using DevExpress.Data;
using DevExpress.XtraGrid.Views.Grid.Customization;
using DevExpress.XtraEditors;
using DevExpress.XtraEditors.Customization;

namespace CGrid
{
    public class CGridControl : GridControl
    {
        protected override void RegisterAvailableViewsCore(InfoCollection collection)
        {
            base.RegisterAvailableViewsCore(collection);
            collection.Add(new CGridViewInfoRegistrator());
        }
        protected override BaseView CreateDefaultView()
        {
            return CreateView("CGridView");
        }
    }

    public class CGridView : GridView
    {
        public CGridView() : this(null) { }

        public CGridView(GridControl gc) : base(gc) {  }

        protected override string ViewName { get { return "CGridView"; } }

        protected override CustomizationForm CreateCustomizationForm()
        {
            return new MyCustomizationForm(this);
        }
    }

    public class CGridViewInfoRegistrator : GridInfoRegistrator
    {
        public override string ViewName { get { return "CGridView"; } }
        public override BaseView CreateView(GridControl grid)
        {
            return new CGridView(grid as GridControl);
        }
    }

    public class MyCustomizationForm : CustomizationForm
    {
        public MyCustomizationForm(GridView view) : base(view) { }

        private string _pattern;
        public string Pattern { 
            get { return _pattern; }
            set
            {
                _pattern = value;
                this.ActiveListBox.Populate();
            }
        }

        private TextEdit fPatternEdit;

        protected override void CreateListBox()
        {
            base.CreateListBox();
            ActiveListBox.Dock = DockStyle.Fill;
            ActiveListBox.Populate();
            Controls.Add(ActiveListBox);
            fPatternEdit = new TextEdit();
            fPatternEdit.Dock = DockStyle.Top;
            Controls.Add(fPatternEdit);
            fPatternEdit.DataBindings.Add("EditValue", this, "Pattern", true, DataSourceUpdateMode.OnPropertyChanged);
         
        }



        protected override CustomizationListBoxBase CreateCustomizationListBox()
        {
            MyColumnCustomizationListBox fActiveListBox = new MyColumnCustomizationListBox(this);
            return fActiveListBox;
        }
    }

    public class MyColumnCustomizationListBox : ColumnCustomizationListBox
    {
        public MyColumnCustomizationListBox(CustomizationForm form) : base(form) { }
        public override void Populate()
        {
            string pattern = (this.CustomizationForm as MyCustomizationForm).Pattern;
            base.Items.BeginUpdate();
            try
            {
                base.Items.Clear();
                ArrayList list = new ArrayList();
                foreach (GridColumn column in base.View.Columns)
                {
                    if (column.CanShowInCustomizationForm)
                    {
                        if (string.IsNullOrEmpty(pattern) || GetCustomizationCaption(column).StartsWith(pattern))
                        {
                            list.Add(column);
                        }
                    }
                }
                list.Sort(new ColumnComparer());
                foreach (GridColumn column in list)
                {
                    base.Items.Add(column);
                }
            }
            finally
            {
                base.Items.EndUpdate();
            }

        }

        private static string GetCustomizationCaption(GridColumn col)
        {
            string s = col.CustomizationCaption;
            if (string.IsNullOrEmpty(s))
                s = col.Caption;
            if (string.IsNullOrEmpty(s))
                s = col.FieldName;
            return s;
        }

        private class ColumnComparer : IComparer
        {
            int IComparer.Compare(object a, object b)
            {
                GridColumn c1 = (GridColumn)a;
                GridColumn c2 = (GridColumn)b;
                int res = Comparer.Default.Compare(GetCustomizationCaption(c1), GetCustomizationCaption(c2));
                if (res == 0)
                {
                    res = Comparer.Default.Compare(c1.AbsoluteIndex, c2.AbsoluteIndex);
                }
                return res;
            }
        }
    }
}