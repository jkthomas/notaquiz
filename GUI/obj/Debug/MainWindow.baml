   M S B A M L   `   `   `  ����>  :GUI, Version=1.0.0.0, Culture=neutral, PublicKeyToken=nullclr-namespace:GUIGUI  5   	       GUI.MainWindow   5   	   R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35D 9http://schemas.microsoft.com/winfx/2006/xaml/presentation    5   	   R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5   	   @d2http://schemas.microsoft.com/expression/blend/2008     5   	   Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5   	   #localclr-namespace:GUI     5   	     � Title$  
MainWindow��5   	   $	��522��6   $	��491��6)   .��5	      � $��	0,253,0,0q�6   .+�5
   
   �� $
��Left=�6-   $��10,-247,0,0q�6H   $	��Top=�6]   $	��200��6u   $	��463��6�   ��6   �� *
Question+6�   �� 5   
   -   5         ��Name$ Buttons��5      $��	0,-83,0,0q�6I   $	��250��6\   ��6)   �� *	Buttons+��5      �� 5      .R�5      �� $��2,2,2,3q�6�   $
��Auto��6�   $��50��6�   ��6   �� *	Content+��69   ��  �� ElementName$ Buttons�� �� Path$% DataContext.SelectButtonCommand���6�   �� $ Content�6�   5      5      �� 5   
   $��Questions guessed right: ��6   $
��Left=�64   $��	0,203,0,0q�6O   $	��Top=�6b   $	��142��6z   �� 5   
   $
��Left=�62   $��142,204,0,0q�6M   $	��Top=�6b   $��20��6z   $��26��6�   ��6   �� *QuestionsProp+6�   �� 5   
   $��/��6   $
��Left=�6   $��162,204,0,0q�67   $	��Top=�6L   $��20��6d   �� 5   
   $
��Left=�64   $��182,204,0,0q�6O   $	��Top=�6d   $��20��6|   $��26��6�   ��6   �� *QuestionsAmount+6�   �� 5   
   $��Question number: ��6   $
��Left=�6,   $��331,203,0,0q�6G   $	��Top=�6\   $	��107��6t   �� 5   
   $
��Left=�63   $��438,203,0,0q�6N   $	��Top=�6c   $��20��6{   $��26��6�   ��6   �� *QuestionNumber+6�   5      5      