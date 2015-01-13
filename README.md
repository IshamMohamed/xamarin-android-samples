# Xamarin Android Samples
Simple solutions built using Xamarin.Android. I hope to provide some interesting code snippets for Xamarin Android. Most of these have a single button and give output on a toast message. Targetted framework for all these solutions are Android 4.4 and above. 

### Solutions
* **BatteryPercentage** - This uses `BatteryManager` class to find the remaining juice in the device. The % of juice is shown as a toast message on button click. [learn more](https://programmium.wordpress.com/2014/12/15/get-android-device-battery-percentage-in-xamarin/)
* **ControllRinger** - First of all sorry for the bad typo, this should be ControlRinger. This uses `AudioManager` class in `Android.Media` namespace to increase / decrease volumes of ringer, alarm, media  & etc. and set device to vibration or silent modes. [learn more](https://programmium.wordpress.com/2014/12/15/audiomanager-in-xamarin-android/)
* **CountLines** - Android doesn't come with a easy method to count line in a <code>TextView</code> so I made this sample for that. [learn more](https://programmium.wordpress.com/2014/12/27/get-line-counts-of-a-textview-in-xamarin-android/)
* **LightSensor** - This uses `SensorManager` class from `Android.Hardware` namespace to retrive ambient light level from sensor and the button click shows a toast message with the name of the vendor the sensor. [learn more](https://programmium.wordpress.com/2015/01/09/retrieve-data-from-light-sensor-with-xamarin-android/)
