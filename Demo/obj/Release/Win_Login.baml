   M S B A M L   `   `   `  ���� ?  ;Demo, Version=1.0.0.0, Culture=neutral, PublicKeyToken=nullclr-namespace:DemoDemo      Demo.Win_Login   R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35D 9http://schemas.microsoft.com/winfx/2006/xaml/presentation    R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     @d2http://schemas.microsoft.com/expression/blend/2008     Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     $localclr-namespace:Demo     -     � Title$  
MainWindow��$	��310��$	��810�� � WindowStyle$
 None=� � WindowStartupLocation$ CenterScreen=� � AllowsTransparency . 
������  � 	Resources    Button_Menu �� 
TargetType �� Property �� Value �� 
TargetType	 ��Name  ForgroundBrush
 ��Name �� Triggers P� Property P� Value �� 
TargetName  ForgroundBrush100��%|  &	        �� " ��.���  � ��$ 0q���  � ��
 �   ���  � �� �� " ��.R��� $	 MyBackgroundElement��#���  $��0q�._��� $
 ButtonContentPresenter��$��Center=�$��Center=� P�  �@J�IsMouseOver . . ��� $ MyBackgroundElement��# �   � ���� $ MyBackgroundElement�� �@J�Opacity$	 0.7Q���  �@�Cursor$
 Hand��.���� -   $��canvas��.+�� -   $��180,0q�$	��300������  �� ImageSource$ image\background.jpg�� � RowDefinitions �� $��30 ��� $	��200 ��� $��* �.+��� -   $��Lab_IP��$��100,0q�$��	IP设置:��$��Right=�$	��Top=�$��Center=�$��25��$y�Hidden=�
������ $��0q�$��1���� -    ��Name$ Tbx_IP��$��Right=�$��Center=�$��25��$��1��$	��100��$y�Hidden=�$	��Top=�
������ $��0q���  �� Orientation$ 
Horizontal=�$��Right=�$��Center=�.+��� -   $��Btn_Setting��$��25��$��25��#��[  .���� $��Icon/setting.png��$��Uniform=��� -   $��Btn_Minimize��$��25��$��25��#��[  .���� $��Icon/mini.png��$��Uniform=��� -   $��	Btn_Close��$��25��$��25��#��[  .���� $��Icon/close.png��$��Uniform=��� $��1��$��80,30q�$	��Top=�$��
Cool Guard��$��25(�$
��Bold"�
��������� $��1��$��80,40q�$	��Top=�$��Right=�$��财务审核平台��$��18(�
��������� $��1��.+�� $	��100��
������ $��1��$��80q� � ColumnDefinitions �� $	��100 ��� ��  �� $��* ��� $��* ��� $��25 �.+��� $��3��$��image\logo.jpg���� -	   $��Cbx_User��$��1��$��2�� �� 
IsEditable . $��Center=�$	��Top=�$��30��$	��180��$��10,0,0,0q�&   System.Windows.Media.TextOptions   TextFormattingMode$ Display=� w� TextPath$
 Name��$��0������ .R�� $	��165��$��30�� �� $	��145 ��� $��20 �.+��� $��0��$��Center=�����  �� Path$
 Name��� -
   $��1��$��Center=�$��Center=�$��×��
������ $��0q�$��20��$��20��
 � Tag �� $
 Name��� $��1��$��2��$��Bottom=�$��记住密码��$��10,0,0,0q�$��Center=��� $��2��$��2��$��忘记密码?��$��Bottom=�$��10,0,0,0q�#��[  �� -   $��	Btn_Login��$��2��$	��180��$��40��$��Center=�$��登     录��$��18(�#��[  �� $��1��$��180,120q�.+�   Demo.SoftKeyboardForPwd  -     Name$ softkeyboard��$��1��$��1��$��2��$��Bottom=�