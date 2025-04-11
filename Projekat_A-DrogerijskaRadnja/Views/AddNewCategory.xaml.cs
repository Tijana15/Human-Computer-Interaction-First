using Projekat_A_DrogerijskaRadnja.Model;
using Projekat_A_DrogerijskaRadnja.Services;
using System.Collections.Generic;
using System.Windows;

namespace Projekat_A_DrogerijskaRadnja.Views
{
    public partial class AddNewCategory : Window
    {
        public List<Department> departments = new List<Department>();
        public DepartmentService departmentService = new DepartmentService();
        private CategoryService categoryService;
        public string CategoryName => txtName.Text;
        public string Description => txtDescription.Text;
        public Department SelectedDepartment => cmbDepartments.SelectedItem as Department;
        public AddNewCategory()
        {
            InitializeComponent();
            categoryService = new CategoryService();
            LoadDepartments();
        }
        private void LoadDepartments()
        {
            departments = departmentService.getDepartments();
            cmbDepartments.ItemsSource = departments;
            cmbDepartments.DisplayMemberPath = "Name";
        }

        private void BtnSave_Click(object sender, RoutedEventArgs e)
        {
            if (ValidateInput())
            {
                var selectedDepartment = cmbDepartments.SelectedItem as Department;
                int departmentId = selectedDepartment.Id_Department;
                
                var newCategory = new Category
                {
                    Name = txtName.Text,
                    Description = txtDescription.Text,
                    DepartmentId = departmentId
                };

                categoryService.AddCategory(newCategory);
                Close();
            }

        }

        private void BtnCancel_Click(object sender, RoutedEventArgs e)
        {
            DialogResult = false;
            Close();
        }

        private bool ValidateInput()
        {
            if (string.IsNullOrWhiteSpace(txtName.Text))
            {
                string message = TryFindResource("NameOfCategoryMissing") as string;
                MessageBox.Show(message);
                return false;
            }
            if (string.IsNullOrWhiteSpace(txtDescription.Text))
            {
                string message = TryFindResource("DescriptionOfCategoryMissing") as string;
                MessageBox.Show(message);
                return false;
            }
            if (string.IsNullOrEmpty(cmbDepartments.Text))
            {
                string message = TryFindResource("DepartmentOfCategoryMissing") as string;
                MessageBox.Show(message);
            }

            return true;
        }

    }
}
