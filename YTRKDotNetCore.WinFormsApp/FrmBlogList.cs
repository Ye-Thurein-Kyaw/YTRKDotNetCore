using Dapper;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using YTRKDotNetCore.Shared;
using YTRKDotNetCore.WinFormsApp.Models;
using YTRKDotNetCore.WinFormsApp.Queries;

namespace YTRKDotNetCore.WinFormsApp
{
    public partial class FrmBlogList : Form
    {
        private readonly DapperService _dapperService;
        //private const int _edit = 4;
        //private const int _delete = 5;
        public FrmBlogList()
        {
            InitializeComponent();
            dgvData.AutoGenerateColumns = false;
            _dapperService = new DapperService(ConnectionStrings.sqlConnectionStringBuilder.ConnectionString);
        }

        private void FrmBlogList_Load(object sender, EventArgs e)
        {
            BlogList();
        }

        private void BlogList()
        {
            List<BlogModel> lst = _dapperService.Query<BlogModel>(BlogQuery.BlogList);
            dgvData.DataSource = lst;
        }

        private void dgvData_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            //int columnIndex = e.ColumnIndex;
            //int rowIndex = e.RowIndex;

            if (e.RowIndex == -1) return;

            #region If Case

            var blogId = Convert.ToInt32(dgvData.Rows[e.RowIndex].Cells["colId"].Value);

            if (e.ColumnIndex == (int)EnumFormControlType.Edit)
            {
                FrmBlog frm = new FrmBlog(blogId);
                frm.ShowDialog();

                BlogList();
            }
            else if (e.ColumnIndex == (int)EnumFormControlType.Delete)
            {
                
            }

            #endregion

            //#region Switch Case

            //int index = e.RowIndex;
            //EnumFormControlType enumFormControlType = (EnumFormControlType)index;

            //switch (enumFormControlType)
            //{

            //    case EnumFormControlType.Edit:
            //        FrmBlog frm = new FrmBlog(blogId);
            //        frm.ShowDialog();

            //        BlogList();
            //        break;
            //    case EnumFormControlType.Delete:
            //        var dialogResult = MessageBox.Show("Are you sure want to delete?", "", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            //        if (dialogResult != DialogResult.Yes) return;

            //        DeleteBlog(blogId);
            //        break;
            //    case EnumFormControlType.None:
            //    default:
            //        MessageBox.Show("Invalid case");
            //        break;
            //}

            //#endregion


        }


        private void DeleteBlog(int id)
        {
            int result = _dapperService.Execute(BlogQuery.BlogDelete, new { BlogId = id });
            string message = result > 0 ? "Delete Success" : "Delete Fail";
            MessageBox.Show(message);
            BlogList();
        }
    }
}
