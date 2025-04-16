using Projekat_A_DrogerijskaRadnja.Model;
using Projekat_A_DrogerijskaRadnja.Services;
using System.Collections.Generic;
using System.Linq;
using System.Windows;

namespace Projekat_A_DrogerijskaRadnja.Views
{
    public partial class EditCategoryWindow : Window
    {
        private readonly Category category;
        private readonly CategoryService categoryService;
        public List<Department> departments = new List<Department>();
        public DepartmentService departmentService = new DepartmentService();
        public EditCategoryWindow(Category category_)
        {
            InitializeComponent();
            categoryService = new CategoryService();
            category = category_;
            txtName.Text = category.Name;
            txtDescription.Text = category.Description;
            LoadDepartments();
            
        }
        private void LoadDepartments()
        {
            departments = departmentService.getDepartments();
            cmbDepartments.ItemsSource = departments;
            cmbDepartments.DisplayMemberPath = "Name";
            cmbDepartments.SelectedValuePath = "Id_Department";

            var initialDepartment = departments
                .FirstOrDefault(d => d.Id_Department == category.DepartmentId); 

            if (initialDepartment != null)
            {
                cmbDepartments.SelectedItem = initialDepartment;
            }
            else
            {
                cmbDepartments.SelectedIndex = 0;
            }
        }
        private void BtnDelete_Click(object sender, RoutedEventArgs e)
        {
                
            var result = MessageBox.Show(TryFindResource("YouSure") as string,
                                        "", MessageBoxButton.YesNo, MessageBoxImage.Warning);
            if (result == MessageBoxResult.Yes)
            {
                DeleteCategory(category.CategoryId);
                this.Close();
            }
        }

        private void BtnUpdate_Click(object sender, RoutedEventArgs e)
        {
            category.Name = txtName.Text;
            category.Description = txtDescription.Text;
            var selectedDepartment = cmbDepartments.SelectedItem as Department;
            if (selectedDepartment != null)
            {
                category.DepartmentId = selectedDepartment.Id_Department;
                UpdateCategory(category);
                this.Close();
            }
            else
            {
                MessageBox.Show(TryFindResource("DepartmentOfCategoryMissing") as string);
            }
           
        }

        private void DeleteCategory(int categoryId)
        {
            categoryService.DeleteCategory(categoryId);
        }

        private void UpdateCategory(Category category)
        {
            categoryService.UpdateCategory(category);
        }
    }

}
