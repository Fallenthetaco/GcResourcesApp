﻿using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
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

namespace DivideGT
{
    /// <summary>
    /// Interaction logic for AttackDisplay.xaml
    /// </summary>
    public partial class FullAttackDisplay : UserControl, INotifyPropertyChanged
    {
        protected override System.Windows.Automation.Peers.AutomationPeer OnCreateAutomationPeer()
        {
            return null;
        }

        public Attack AttackDataInfo
        {
            get => (Attack)GetValue(AttackDataInfoProperty);
            set => SetValue(AttackDataInfoProperty, value);
        }

        public FullAttackDisplay()
        {            
            InitializeComponent();
        }

        public static readonly DependencyProperty AttackDataInfoProperty = DependencyProperty.Register("AttackDataInfo", typeof(Attack), typeof(FullAttackDisplay),
            new PropertyMetadata(new Attack(), new PropertyChangedCallback(OnAttackDataChanged)));

        private static void OnAttackDataChanged(DependencyObject d, DependencyPropertyChangedEventArgs e)
        {
            FullAttackDisplay ad = d as FullAttackDisplay;
            ad.OnAttackDataChanged(e);
        }

        private void OnAttackDataChanged(DependencyPropertyChangedEventArgs e)
        {
            OnPropertyChanged("AttackData");
        }

        #region PropertyChanged

        public event PropertyChangedEventHandler PropertyChanged;
        private void OnPropertyChanged(string propertyName)
        {
            PropertyChangedEventHandler handler = PropertyChanged;
            if (handler != null)
            {
                handler(this, new PropertyChangedEventArgs(propertyName));
            }
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
