   M S B A M L   `   `   `  ����F  BPointyClick, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null)clr-namespace:PointyClickPointyClick  5   	       PointyClick.MainWindow   5   	   W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35^ ZWindowsFormsIntegration, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35F 9http://schemas.microsoft.com/winfx/2006/xaml/presentation     5   	   R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5   	   @d2http://schemas.microsoft.com/expression/blend/2008     5   	   Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5   	   +localclr-namespace:PointyClick     5   	     � Title$  
MainWindow��5   	   $	��800��6   $
��1000��6)   .��5
      � .+�5   
   �� -   5         ��Name$ loadCSV��5      $��Browse��6"   $
��Left=�63   $��21��6N   $��348,144,0,0q�6Z   $	��Top=�6o   $��63��6�   6�   �� 5   
   -   5         ��Name$ filePath��5      $
��Left=�6$   $��21��6?   $��
78,144,0,0q�6K    �� TextWrapping$
 Wrap=�6_   $	��Top=�6s   $	��265��6�    �� 
IsReadOnly . 6�   �� 5   
   -   5         ��Name$ 	textBlock��5      $
��Left=�6'   $��21��6B   $��
25,144,0,0q�6N   $
��Wrap=�6b   $��
File Path:��6v   $	��Top=�6�   $��48��6�   �� 5   
   -   5        $ button1��5      $��Import��6"   $
��Left=�63   $��26��6N   $��843,723,0,0q�6Z   $	��Top=�6o   $	��111��6�    J� RenderTransformOrigin$ 0.838,6.269&�6�   �� 5   
   -   5         ��Name$ pm_by_pcs_png��5      $��10,10,781,652q�6'   $��pm-by-pcs.png��6>   $
��Fill=�6U   &   System.Windows.Controls.DataGrid  5   
   -   5        $��	dataGrid1��5      $
��Left=�6$   $	��528��6?   $	��Top=�6L   $	��220��6d   $��734,170,0,0q�6p      
IsReadOnly . 	   AutoGenerateColumns	 . 
   CanUserSortColumns
 .     CanUserResizeColumns .     CanUserResizeRows .   � 	Resources 5      ��%    5      5        5   
   -   5        $��	dataGrid2��5      $
��Left=�6$   $	��528��6?   $	��Top=�6L   $	��433��6d   $��
25,170,0,0q�6p   	 . 
 .  $ �� IsSynchronizedWithCurrentItem$
 TrueY�5"       .    SelectionUnit$
 Cell=�5$       .   .   5'      =  7System.Windows.Controls.Primitives.DataGridColumnHeader �� 
TargetType��%E   '        �� 5(      "  6   .�5)      -   5        5*      5+         Columns 5,      5/        53   
   -	   5        $��	dataGrid3��53      $
��Left=�6$   $	��528��6?   $	��Top=�6L   $	��220��6d   $��489,170,0,0q�6p   
 .  $
 TrueY�55       .    SelectionMode$ Single=�56   %   $ CellOrRowHeader=�6<    .   .  5G      5I      5K      