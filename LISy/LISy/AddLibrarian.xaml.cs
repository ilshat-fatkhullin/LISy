﻿using LISy.Managers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;

namespace LISy
{
	/// <summary>
	/// Логика взаимодействия для AddLibrarian.xaml
	/// </summary>
	public partial class AddLibrarian : Window
	{
		/// <summary>
		/// Initializes window for adding librarian.
		/// </summary>
		public AddLibrarian()
		{
			InitializeComponent();
		}

		private void lib_name_box_TextChanged(object sender, TextChangedEventArgs e)
		{
			InputFieldsManager.CheckLiteralValidity(lib_name_box);
		}

		private void lib_status_box_TextChanged(object sender, TextChangedEventArgs e)
		{
			InputFieldsManager.CheckLiteralValidity(lib_status_box);
		}

		private void add_new_lib_to_system_Click(object sender, RoutedEventArgs e)
		{
			if (InputFieldsManager.CheckPasswordValidity(lib_password_box) && lib_status_box.Text != null && lib_name_box.Text != null)
			{
				//add new lib to the system
				this.Close();
			}
		}
	}
}
