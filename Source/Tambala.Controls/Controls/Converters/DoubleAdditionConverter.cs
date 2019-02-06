﻿using System;
using System.Windows.Data;
using System.Windows.Markup;

namespace Restless.App.Tambala.Controls
{
    /// <summary>
    /// Provides a converter that accepts a double value and returns a value added to the converter parameter.
    /// </summary>
    internal class DoubleAdditionConverter : MarkupExtension, IValueConverter
    {
        #region Public methods
        /// <summary>
        /// Converts a double value to a specified percentage of the value.
        /// </summary>
        /// <param name="value">The double value.</param>
        /// <param name="targetType">The target type.</param>
        /// <param name="parameter">The value</param>
        /// <param name="culture">Not used</param>
        /// <returns>A perecentage of <paramref name="value"/></returns>
        public object Convert(object value, Type targetType, object parameter, System.Globalization.CultureInfo culture)
        {
            if (value is double v && parameter != null && double.TryParse(parameter.ToString(), out double factor))
            {
                return v + factor;
            }
            return value;
        }

        /// <summary>
        /// This method is not used. It throws a <see cref="NotImplementedException"/>
        /// </summary>
        /// <param name="value">n/a</param>
        /// <param name="targetType">n/a</param>
        /// <param name="parameter">n/a</param>
        /// <param name="culture">n/a</param>
        /// <returns>n/a</returns>
        public object ConvertBack(object value, Type targetType, object parameter, System.Globalization.CultureInfo culture)
        {
            throw new NotImplementedException();
        }

        /// <summary>
        /// Gets the object that is set as the value of the target property for this markup extension. 
        /// </summary>
        /// <param name="serviceProvider">Object that can provide services for the markup extension.</param>
        /// <returns>This object.</returns>
        public override object ProvideValue(IServiceProvider serviceProvider)
        {
            return this;
        }
        #endregion
    }
}
