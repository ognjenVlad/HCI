   M S B A M L   `   `   `  ����E  ARasporedRC, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null'clr-namespace:RasporedRC
RasporedRC  5   	       RasporedRC.UpdateSoftware   5   	   \ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35D 9http://schemas.microsoft.com/winfx/2006/xaml/presentation    5   	   R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5   	   @d2http://schemas.microsoft.com/expression/blend/2008     5   	   Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5   	   *localclr-namespace:RasporedRC     5   	     � Title$  Izmena softvera��5      $	��430��6)   $	��400��66    � 
ResizeMode$ NoResize=�6B    � WindowStartupLocation$ CenterScreen=�6X    � 	Resources 5
      &   RasporedRC.EnableButtonConverter   EnableButtonConverter"  RasporedRC.ListViewConverter  ListViewConverter �� 
TargetType �� Property �� Value ��Name��%8  &	        &	      '�� &       5   
   6&     5   
   6"   �� 5   
   " ��6   .�5      ��  �@=�ErrorTemplate 5      �� 5      .R�5      �� .+�5      �� $ textBox��68   �� 5      
���  ����6(   �� *[0].ErrorContent+6J   5      5      5      5      5       .��5!      �� .��5"   
   �  � RowDefinitions 5#      �� 5$      $
��Auto �6    �� 5%      $
��Auto �6    �� 5&      $
��Auto �6    �� 5'      $
��Auto �6    �� 5(      $
��Auto �6    �� 5)      $
��Auto �6    �� 5*      $
��Auto �6    �� 5+      $
��Auto �6    �� 5,      $
��Auto �6    �� 5-      $
��Auto �6    �� 5.      $
��Auto �6    �� 5/      $
��Auto �6    �� 50      $
��Auto �6    �� 51      $
��Auto �6    �� 52      $
��Auto �6    �� 53      $
��Auto �6    �� 55      $
��Auto �6    	 � ColumnDefinitions	 57      �� 58      $	��200 �6#   �� 59      $	��100 �6#   �� 5:      $
��Auto �6#   .+�5=      �� $��0��6   $��0��6!   .��61   Oznaka softvera6B   �� 5>      -   5        
 ��Name$
 oznaka��5>      $��0��6&   $��1��63   $��5q�6C   .��6N   ��5?      �� 5@       �� Path$ softwareToUpdate.label�6    �� UpdateSourceTrigger$ PropertyChanged=�6<    �� ValidationRules 5B        RasporedRC.ValidateLabel  5C      
   tip$ softver��62   5F      .��5G       5I      �� 5J      $��1��6   6#   �� 5K      $��2��6   $��0��6!   .��61   Opis softvera:6A   �� 5L      -   5        $

 opis��5L       �� TextWrapping$
 Wrap=�6$    �� AcceptsReturn . " �� VerticalScrollBarVisibility$ Visible=�5N      $��2��6)   $��1��66   $��5q�6F   $��15��6Q   $��50��6_   $	��500��6n   $��50��6}   .��6�   ��5O      �� 5P      $" softwareToUpdate.description�6   $ PropertyChanged=�6B    5R         RasporedRC.EmptyValidation  5S      5V      .��5W       5X      �� 5Y      $��3��6   6#   �� 5[      $��4��6   $��0��6!   .��61   Datum izdavanja:6C   (  "System.Windows.Controls.DatePicker  5\      -   5          Name$ godina��5\   �   $��4��6E   $��1��6R   $��5q�6�      SelectedDate 6b   �� *#!softwareToUpdate.yearOfPublishing+5^      �� 5_      $��5��6   6#   �� 5a      $��6��6   $��0��6!   .��61   Naziv softvera:6B   �� 5b      -   5        $	
 ime��5b      $��6��6#   $��1��60   $��5q�6@   .��6K   ��5c      �� 5d      $ softwareToUpdate.name�6   $ PropertyChanged=�6;    5f        5g      5j      .��5k       5l      �� 5n      $��7��6   6#   �� 5p      $��8��6   $��0��6!   .��61   Proizvođač softvera:6G   �� 5q      -   5        $
 proizvodjac��5q      $��8��6+   $��1��68   $��5q�6H   .��6S   ��5r      �� 5s      $# softwareToUpdate.manofacturer�6   $ PropertyChanged=�6C    5u        5v      5y      .��5z       5{      �� 5|      $��9��6   6#   �� 5~      $��10��6   $��0��6"   .��62   
Webiste:6<   �� 5      -   5        $

 sajt��5      $��10��6$   $��1��62   $��5q�6B   .��6M   ��5�      �� 5�      $ softwareToUpdate.website�6   $ PropertyChanged=�6>    5�        5�      5�      .��5�       5�      �� 5�      $��11��6   6$   �� 5�      $��12��6   $��0��6"   .��62   Cena:69   �� 5�      -   5        $

 cena��5�      $��12��6$   $��1��62   $��5q�6B   .��6M   ��5�      �� 5�       �� StringFormat$ N2��6   $ softwareToUpdate.price�60   $ PropertyChanged=�6N    5�         RasporedRC.Validation  5�      
   tip$ double��6/   5�      .��5�       5�      �� 5�      $��13��6   6$   �� 5�      $��15��6   6$   �� 5�      -   5         ��Name$	 add��5�   #   $��16��6   $��Izmeni softver��6G   $��10,10,-64,10q�6`   $��25��6w   $��3��6�   ��5�      �� 5�      " ��6   .�5�      ��  � {� .  66    �� Triggers 5�      ^� 5�       ^� 
Conditions 5�   "   �� 5�   &    �� Binding 60   ��  �� ElementName$	 ime��$ (Validation.HasError)� �� Value	 false6p   �� 5�   &    60   �� $
 opis��$ (Validation.HasError)�	 false6q   �� 5�   &    60   �� $ oznaka��$ (Validation.HasError)�	 false6s   �� 5�   &    60   �� $ godina��$ (Validation.HasError)�	 false6s   �� 5�   &    60   �� $ proizvodjac��$ (Validation.HasError)�	 false6x   �� 5�   &    60   �� $
 cena��$ (Validation.HasError)�	 false6q   �� 5�   &    60   �� $
 sajt��$ (Validation.HasError)�	 false6q   �� 5�   &    60   �� $
 opis��$ Text.Length� �� 	Converter# [  	 false6�   �� 5�   &    60   �� $ oznaka��$ Text.Length�# [  	 false6�   �� 5�   &    60   �� $ godina��$ Text.Length�# [  	 false6�   �� 5�   &    60   �� $	 ime��$ Text.Length�# [  	 false6�   �� 5�   &    60   �� $
 sajt��$ Text.Length�# [  	 false6�   �� 5�   &    60   �� $ proizvodjac��$ Text.Length�# [  	 false6�   �� 5�   &    60   �� $
 cena��$ Text.Length�# [  	 false6�   .0�5�   "   ��  � {� . 6>   5�      5�      5�      5�      5�      5�      