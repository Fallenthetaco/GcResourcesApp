﻿using DivideGT;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Linq.Expressions;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace DivideGtCommons.Controls
{
    /// <summary>
    /// Interaction logic for DefenseHistory.xaml
    /// </summary>
    public partial class AttackHistory : UserControl, INotifyPropertyChanged
    {
        public string PlayerName { get; set; }

        public string GuildName { get; set; }

        public int Position { get; set; }

        private List<TournamentRecord> _records;
        public List<TournamentRecord> Records
        {
            get => _records;
            set => SetProperty(ref _records, value);
        }

        public AttackHistory()
        {
            InitializeComponent();
            DataContext = this;
        }

        #region Property Changed

        public event PropertyChangedEventHandler PropertyChanged;

        protected virtual void OnPropertyChanged([CallerMemberName] string propertyName = null)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }

        protected virtual void OnPropertyChanged<T>(Expression<Func<T>> raiser)
        {
            var propName = ((MemberExpression)raiser?.Body)?.Member.Name;
            OnPropertyChanged(propName);
        }

        protected bool SetProperty<T>(ref T field, T value, [CallerMemberName] string name = null)
        {
            if (EqualityComparer<T>.Default.Equals(field, value)) return false;
            field = value;
            OnPropertyChanged(name);
            return true;
        }

        #endregion
    }
}
