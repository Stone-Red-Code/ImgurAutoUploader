   M S B A M L   `   `   `  ���� L  HImgurAutoUploader, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null5clr-namespace:ImgurAutoUploaderImgurAutoUploader      ImgurAutoUploader.Popup   \ XPresentationFramework, Version=5.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35e aSystem.Windows.Controls.Ribbon, Version=5.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089W SPresentationCore, Version=5.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35R NWindowsBase, Version=5.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35F 9http://schemas.microsoft.com/winfx/2006/xaml/presentation     R NSystem.Xaml, Version=5.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     @d2http://schemas.microsoft.com/expression/blend/2008     Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     1localclr-namespace:ImgurAutoUploader       � WindowStyle$
  None=� � 
ResizeMode$ NoResize=� � Topmost$
 True�� � Title$ Popup��$	��259��$	��419�� � 	Resources    FancyButton �� 
TargetType �� Property �� Value �� 
TargetType��%�   &	        �� " ��.���  �@�OverridesDefaultStyle$
 True����  �@�Cursor$
 Hand����  � �� �� " ��.R��� $��border��$��0q�
���   �#��z��._��� $��Center=�$��Center=�.��� -   	 �Name$
	 grid�����#2C2C2C
 � RowDefinitions
 �� $��8* ��� $��1* �.+��� -   #��[   � Cursor$
 Hand������ .��� .+��� -    ��Name$ imageBox��$��Uniform=��� -    ��Name$ 	editLabel��$
��EDIT��$y�	Collapsed=�$��Center=�$��Center=�$��36(�$
��Bold"�$��Myanmar Text)�� $��1��$��2�� � ColumnDefinitions �� $��1* ��� $��1* �.+�� -    �Name$ UploadProgressBar��$y�	Collapsed=� � IsIndeterminate$
 True��$��2���� -    ��Name$ LinkTextBlock��$y�	Collapsed=�$��2�� �� TextAlignment$ Center=�$��Center=�
��������� -    ��Name$ UploadButton��$��Upload���� -   $ SecretButton��$��It's a secret��$��1��