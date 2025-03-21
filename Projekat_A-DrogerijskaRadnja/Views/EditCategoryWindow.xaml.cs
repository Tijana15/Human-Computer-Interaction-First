﻿using Projekat_A_DrogerijskaRadnja.Model;
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
            cmbDepartments.DisplayMemberPath = "Name";
            cmbDepartments.SelectedValuePath = "DepartmentId";
            LoadDepartments();
            var department = cmbDepartments.Items
                       .OfType<Department>()
                       .FirstOrDefault(d => d.Id_Department == category.DepartmentId);
            if (department != null)
            {
                cmbDepartments.Text = department.Name;
            }
        }
        private void LoadDepartments()
        {
            departments = departmentService.getDepartments();
            cmbDepartments.ItemsSource = departments;
            cmbDepartments.Text=category.Name;
            cmbDepartments.DisplayMemberPath = "Name";
        }
        private void BtnDelete_Click(object sender, RoutedEventArgs e)
        {
            var result = MessageBox.Show("Are you sure you want to delete this category? This action cannot be undone.",
                                        "Confirm Delete", MessageBoxButton.YesNo, MessageBoxImage.Warning);
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
            category.DepartmentId = selectedDepartment.Id_Department;
            UpdateCategory(category);
            this.Close();
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
