   M S B A M L   `   `   `  ����E  ARasporedRC, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null'clr-namespace:RasporedRC
RasporedRC  5   	       RasporedRC.UpdateCourse   5   	   \ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35D 9http://schemas.microsoft.com/winfx/2006/xaml/presentation    5   	   R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5   	   @d2http://schemas.microsoft.com/expression/blend/2008     5   	   Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5   	   *localclr-namespace:RasporedRC     5   	     � Title$  Izmena smera��5   	   $	��430��6   $	��400��6+    � 
ResizeMode$ NoResize=�67    � WindowStartupLocation$ CenterScreen=�6M    � 	Resources 5	      &   RasporedRC.EnableButtonConverter   EnableButtonConverter"  RasporedRC.ListViewConverter  ListViewConverter �� 
TargetType �� Property �� Value ��Name��%8  &	        &	      '�� &       5
   
   6&     5   
   6"   �� 5   
   " ��6   .�5      ��  �@=�ErrorTemplate 5      �� 5      .R�5      �� .+�5      �� $ textBox��68   �� 5      
���  ����6(   �� *[0].ErrorContent+6J   5      5      5      5      5      .��5       �� .��5!   
   �  � RowDefinitions 5"      �� 5#      $
��Auto �6    �� 5$      $
��Auto �6    �� 5%      $
��Auto �6    �� 5&      $
��Auto �6    �� 5'      $
��Auto �6    �� 5(      $
��Auto �6    �� 5)      $
��Auto �6    �� 5*      $
��Auto �6    �� 5+      $
��Auto �6    	 � ColumnDefinitions	 5-      �� 5.      $	��200 �6#   �� 5/      $	��100 �6#   �� 50      $
��Auto �6#   .+�53      �� $��0��6   $��0��6!   .��61   Oznaka smera:6@   �� 54      -   5        
 ��Name$
 oznaka��54      $��0��6&   $��1��63   $��5q�6C   .��6N   ��55      �� 56       �� Path$ courseToUpdate.label�6    �� UpdateSourceTrigger$ PropertyChanged=�6:    �� ValidationRules 58        RasporedRC.ValidateLabel  59      
   tip$
 smer��62   5<      .��5=       5?      �� 5@      $��1��6   6#   �� 5A      $��2��6   $��0��6!   .��61   Opis smera:6>   �� 5B      -   5        $

 opis��5B       �� TextWrapping$
 Wrap=�6$    �� AcceptsReturn . " �� VerticalScrollBarVisibility$ Visible=�5D      $��2��6)   $��1��66   $��5q�6F   $��15��6Q   $��50��6_   $	��500��6n   $��50��6}   .��6�   ��5E      �� 5F      $  courseToUpdate.description�6   $ PropertyChanged=�6@    5H         RasporedRC.EmptyValidation  5I      5L      .��5M       5N      �� 5O      $��3��6   6#   �� 5Q      $��4��6   $��0��6!   .��61   Datum uvođenja smera:6H   (  "System.Windows.Controls.DatePicker  5R      -   5        $
��year��5R   l   $��4��6   $��1��6'   $��5q�6x      SelectedDate 67   �� *courseToUpdate.startingYear+   BlackoutDates 5S      /  )System.Windows.Controls.CalendarDateRange  5T         Start$ 1/1/0001��6(   
   End$ 
12/31/1969��69   5V      �� 5W      $��5��6   6#   �� 5Y      $��6��6   $��0��6!   .��61   
Ime smera:6=   �� 5Z      -   5        $	
 ime��5Z      $��6��6#   $��1��60   $��5q�6@   .��6K   ��5[      �� 5\      $ courseToUpdate.name�6   $ PropertyChanged=�69    5^        5_      5b      .��5c       5d      �� 5e      $��7��6   6#   �� 5f      -   5         ��Name$	 add��5f   9   $��10,10,-64,10q�6   $��8��6,   $��Izmeni smer��6[   $��25��6q   $��3��6}   ��5h      �� 5i      " ��6   .�5j      ��  � {� .  66    �� Triggers 5k      ^� 5m       ^� 
Conditions 5n   "   �� 5o   &    �� Binding 60   ��  �� ElementName$	 ime��$ (Validation.HasError)� �� Value	 false6p   �� 5p   &    60   �� $
 opis��$ (Validation.HasError)�	 false6q   �� 5q   &    60   �� $ oznaka��$ (Validation.HasError)�	 false6s   �� 5s   &    60   �� $	 ime��$ Text.Length� �� 	Converter# [  	 false6�   �� 5t   &    60   �� $
 opis��$ Text.Length�# [  	 false6�   �� 5v   &    60   �� $ oznaka��$ Text.Length�# [  	 false6�   �� 5w   &    60   �� $
 year��$ Text.Length�# [  	 false6�   .0�5z   "   ��  � {� . 6>   5|      5      5�      5�      5�      5�      