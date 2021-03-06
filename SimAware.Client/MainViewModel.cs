﻿using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Runtime.CompilerServices;
using System.Text;

namespace SimAware.Client
{
    public enum ConnectionState
    {
        Idle, 
        Connecting,
        Connected,
        Failed
    }

    public class MainViewModel : INotifyPropertyChanged
    {
        public event PropertyChangedEventHandler PropertyChanged;

        protected bool SetProperty<T>(ref T storage, T value, [CallerMemberName] string propertyName = null)
        {
            if((storage == null && value != null) || (storage != null && !storage.Equals(value)))
            {
                storage = value;
                PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
                return true;
            }
            return false;
        }

        private ConnectionState simConnectionState = ConnectionState.Idle;

        public ConnectionState SimConnectionState { get => simConnectionState; set => SetProperty(ref simConnectionState, value); }

        private string callsign = null;

        public string Callsign { get => callsign; set => SetProperty(ref callsign, value?.Replace("<", "")); }

        private AircraftStatus aircraftStatus = null;

        public AircraftStatus AircraftStatus { get => aircraftStatus; set => SetProperty(ref aircraftStatus, value); }

    }
}
