﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BazyDanych
{
	class ComboBoxItem
	{
		public ComboBoxItem()
		{
		}

		public ComboBoxItem(string text, object value)
		{
			Text = text;
			Value = value;
		}

		public string Text { get; set; }

		public object Value { get; set; }

		public override string ToString()
		{
			return Text;
		}
	}
}
