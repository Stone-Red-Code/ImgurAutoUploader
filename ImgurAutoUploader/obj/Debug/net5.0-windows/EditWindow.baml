   M S B A M L   `   `   `  ����L  HImgurAutoUploader, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null5clr-namespace:ImgurAutoUploaderImgurAutoUploader  5   	   "    ImgurAutoUploader.EditWindow   5   	   \ XPresentationFramework, Version=5.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35e aSystem.Windows.Controls.Ribbon, Version=5.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089W SPresentationCore, Version=5.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35R NWindowsBase, Version=5.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35F 9http://schemas.microsoft.com/winfx/2006/xaml/presentation     5   	   R NSystem.Xaml, Version=5.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5   	   @d2http://schemas.microsoft.com/expression/blend/2008     5   	   Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5   	   1localclr-namespace:ImgurAutoUploader     5   	   -   5          � Title$  
EditWindow��5	   	   $	��450��6   $	��800��6)   .��5
      � ���#2C2C2C � RowDefinitions 5   
   �� 5      $��* �6   �� 5      $
��30px �6   .+�5   
   (� -   5         (�Name$ viewBox��5       (� Stretch$ Uniform=�6#   .��5      �� -   5         ��Name$ 	inkCanvas��5       �� 
Background
 ����  �� DefaultDrawingAttributes 5      *  $System.Windows.Ink.DrawingAttributes  5      -   5        	attribute��   Width$ 10Q�5   ;      Height$ 10Q�6F   	   Color$		 Red��6R   5      5      � 5   
   $��1��6   
 � ColumnDefinitions
 5      �� 5      $��* �6#   �� 5      $��* �6#   .+�5      � -   5         �Name$ UploadProgressBar��5      $y�	Collapsed=�65    � IsIndeterminate$
 True��6L   $��2��6c   �� 5      -   5         ��Name$ SecretButton��5      $��Upload��6+   $��0��6<   6L   �� 5      -   5        $ UploadButton��5      $
��Save��6+   $��1��6:   6J   5      5       5!      