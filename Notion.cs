using System.Collections.Generic;
using System.Threading.Tasks;
using UnityEngine;


namespace NeurositySDK
{
    public class Notion
    {
        public bool IsLoggedIn { get; private set; }
        public DeviceStatus Status { get; private set; }

        private readonly FirebaseController _firebase;
        private SubscriptionManager _subscriptionManager;
        private NeurosityUser _user;

        public Notion(FirebaseController firebaseController)
        {
            _firebase = firebaseController;
        }

        public async Task Login(Device credientials)
        {
            var u = await _firebase.Login(credientials);
            Debug.Log(u);
            _user = new NeurosityUser(u, _firebase);
            Debug.Log(_user);
            _subscriptionManager = new SubscriptionManager(_firebase, credientials, _user);
            Debug.Log(_subscriptionManager);
            Status = await _user.GetSelectedDeviceStatus();
            Debug.Log(Status);
            IsLoggedIn = true;
        }

        public async Task Logout()
        {
            await _subscriptionManager.Dispose();
            _firebase.Logout();
            IsLoggedIn = false;
        }

        public async Task<IEnumerable<DeviceInfo>> GetDevices()
        {
            return await _user.GetDevices();
        }

        public async Task<DeviceInfo> GetSelectedDevice()
        {
            return await _user.GetSelectedDevice();
        }

        public async Task<DeviceStatus> GetSelectedDeviceStatus()
        {
            return await _user.GetSelectedDeviceStatus();
        }

        public void Subscribe(IMetricHandler handler)
        {
            _subscriptionManager.Subscribe(handler);
        }

        public void Subscribe(ISettingsHandler handler)
        {
            _subscriptionManager.Subscribe(handler);
        }

        public void Unsubscribe(IMetricHandler handler)
        {
            _subscriptionManager.Unsubscribe(handler);
        }

        public void Unsubscribe(ISettingsHandler handler)
        {
            _subscriptionManager.Unsubscribe(handler);
        }

        public async void ChangeSettings(Settings settings)
        {
            await _user.UpdateSettings(settings);
        }

        public async Task RemoveDevice(string deviceId)
        {
            await _user.RemoveDevice(deviceId);
        }

        public async Task RemoveDevice(Device device)
        {
            await RemoveDevice(device.DeviceId);
        }
    }
}