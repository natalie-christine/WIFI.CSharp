   M S B A M L   `   `   `  ����O  KWIFI.CSharp.Teil1, Version=2024.1.0.0, Culture=neutral, PublicKeyToken=nullA%clr-namespace:WIFI.CSharp.Teil1.ViewsWIFI.CSharp.Teil1.Views  5   	   *    $WIFI.CSharp.Teil1.Views.Hauptfenster   5   	   W SPresentationCore, Version=8.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=8.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35e aSystem.Windows.Controls.Ribbon, Version=8.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089R NWindowsBase, Version=8.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35F 9http://schemas.microsoft.com/winfx/2006/xaml/presentation     5   	   R NSystem.Xaml, Version=8.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5   	   @d2http://schemas.microsoft.com/expression/blend/2008     5   	   Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5   	   7local%clr-namespace:WIFI.CSharp.Teil1.Views     5   	   #   WIFI.CSharp.Teil1.Views.Texte    Titel � Title# Z  5	   	   $	��450��5   	   $	��800��5   	   $	��450��5   	   $	��800��5   	   .��5      � $��3q�5   	    � ColumnDefinitions 5   
   �� 5      $��0 �6   �� 5      $	��200 �6   �� 5       � RowDefinitions 5!   
   �� 5#      $��40 �6   �� 5%      �� 5'      $��26 �6   .+�5+   
   �� $��2��5,         Alternativfarbe#��[  5/      $
��14pt(�51      $��Center=�52      ��5.      �� *AktuellerInhalt.Titel+52      �� 57   
   $��0��58      $��2��59       �� Orientation$ 
Horizontal=�5:      $
��Left=�5;      $��26��5<      $��	442,7,0,7q�6   .+�5>      ��    Sprache#��Z 5@      �� 5C      $	��100��5E      $��Right=�5F       �� DisplayMemberPath$
 Name��5I      $��Center=�5M      ��5H      �� *Kontext.Sprachen.Liste+ �� SelectedItem 5K      �� *AktuelleSprache+5M      5O      �� 5R   
   $��0��5S      $��0��5T      $��3��5U      
�������$��2��5W      �� 5]   
   $��0��5_      $��0��5`         Themen#��Z 5b      $��Center=�5c      $
��16pt(�5d      $��2��6   �� 5j   
   $��0��5k      $��0��5l      $
��Left=�5n      $��40��5p      $��40��5q      $��0q�5s      
������ #��[  5u      $��	Wingdings)�5w      $
��18pt(�5x      $��ç��5y      $��2��5{   1   $��	160,0,0,0q�6E   ��6   �� *BegrüßungZeigen+��5�      �� 5�      	 �� 
TargetType"	 ��6   
 �� Triggers
 5�      �� 5�       �� Binding 5�      �� *IstBegrüßung+ �� Value True5�      .a�5�      ��  �� Property � y� �� Value$ 	Collapsed=�5�   !   5�      5�      5�      *   $WIFI.CSharp.Teil1.Views.ThemenViewer  5�   
   $��0��5�      $��1��5�      $��2��6   �� 5�   
   $��0��5�      $��2��5�      $��3,7,0,0q�5�      $	��Top=�5�         BeimBeendenFragen#��Z 5�      $��2��5�   5    d� 	IsChecked 6   �� *BeimBeendenFragen+65   �� 5�   
   $��2��5�      $��1��5�      $��2��5�      ��5�      �� *AktuellerInhalt.View+5�      5�      