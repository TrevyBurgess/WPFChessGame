   M S B A M L   `   `   `  ����d  `TrevyBurgess.Games.TrevyChess.ChessGameUI, Version=1.0.0.0, Culture=neutral, PublicKeyToken=nullw@clr-namespace:TrevyBurgess.Games.TrevyChess.ChessGameUI.Controls2TrevyBurgess.Games.TrevyChess.ChessGameUI.Controls  5   	   E    ?TrevyBurgess.Games.TrevyChess.ChessGameUI.Controls.ChessBoardUi   5   &   RChessControls@clr-namespace:TrevyBurgess.Games.TrevyChess.ChessGameUI.Controls  5   	   R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35D 9http://schemas.microsoft.com/winfx/2006/xaml/presentation    5   	   R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5   	   Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5   	   @d2http://schemas.microsoft.com/expression/blend/2008     5   	   -   5        N   HTrevyBurgess.Games.TrevyChess.ChessGameUI.Controls.ChessBoardControlBase   Name$  TheChessBoard��5   &   N   HTrevyBurgess.Games.TrevyChess.ChessGameUI.Controls.ChessBoardControlBase   Loaded$ TheChessBoard_Loaded��5	   "   $	��846��6	   $	��846��6   .��5
      � 
������� � RowDefinitions 5   
   �� 5      $��* �6   �� 5      $��3* �6   �� 5      $��3* �6   �� 5      $��3* �6   �� 5      $��3* �6   �� 5      $��3* �6   �� 5      $��3* �6   �� 5      $��3* �6   �� 5      $��3* �6   �� 5      $��* �6    � ColumnDefinitions 5   
   �� 5      $��* �6   �� 5      $��3* �6   �� 5      $��3* �6   �� 5      $��3* �6   �� 5      $��3* �6   �� 5      $��3* �6   �� 5      $��3* �6   �� 5       $��3* �6   �� 5!      $��3* �6   �� 5"      $��* �6   .+�5&   
   �� -   5        $��TopCol1��5&      $��1��6#   $��0��63   $	�� A ��6@   $��Center=�6K   $��Center=�6h   �� 5'   
   -   5        $��TopCol2��5'      $��2��6#   $��0��63   $	�� B ��6@   $��Center=�6K   $��Center=�6h   �� 5(   
   -   5        $��TopCol3��5(      $��3��6#   $��0��63   $	�� C ��6@   $��Center=�6K   $��Center=�6h   �� 5)   
   -   5        $��TopCol4��5)      $��4��6#   $��0��63   $	�� D ��6@   $��Center=�6K   $��Center=�6h   �� 5*   
   -   5        $��TopCol5��5*      $��5��6#   $��0��63   $	�� E ��6@   $��Center=�6K   $��Center=�6h   �� 5+   
   -   5        $��TopCol6��5+      $��6��6#   $��0��63   $	�� F ��6@   $��Center=�6K   $��Center=�6h   �� 5,   
   -   5        $��TopCol7��5,      $��7��6#   $��0��63   $	�� G ��6@   $��Center=�6K   $��Center=�6h   �� 5-   
   -	   5        $��TopCol8��5-      $��8��6#   $��0��63   $	�� H ��6@   $��Center=�6K   $��Center=�6h   �� 5/   
   -
   5        $��LeftRow8��5/      $��0��6$   $��1��64   $	�� 8 ��6A   $��Center=�6L   $��Center=�6i   �� 50   
   $��1��6   $��1��6    $
��Fill=�6.   $Y��S/TrevyBurgess.Games.TrevyChess.ChessGameUI;component/Images/ChessPieces/Square2.jpg��6=   �� 51   
   $��2��6   $��1��6    $Y��S/TrevyBurgess.Games.TrevyChess.ChessGameUI;component/Images/ChessPieces/Square1.jpg��6-   $
��Fill=�6�   �� 52   
   $��3��6   $��1��6    $Y��S/TrevyBurgess.Games.TrevyChess.ChessGameUI;component/Images/ChessPieces/Square2.jpg��6-   $
��Fill=�6�   �� 53   
   $��4��6   $��1��6    $Y��S/TrevyBurgess.Games.TrevyChess.ChessGameUI;component/Images/ChessPieces/Square1.jpg��6-   $
��Fill=�6�   �� 54   
   $��5��6   $��1��6    $Y��S/TrevyBurgess.Games.TrevyChess.ChessGameUI;component/Images/ChessPieces/Square2.jpg��6-   $
��Fill=�6�   �� 55   
   $��6��6   $��1��6    $Y��S/TrevyBurgess.Games.TrevyChess.ChessGameUI;component/Images/ChessPieces/Square1.jpg��6-   $
��Fill=�6�   �� 56   
   $��7��6   $��1��6    $Y��S/TrevyBurgess.Games.TrevyChess.ChessGameUI;component/Images/ChessPieces/Square2.jpg��6-   $
��Fill=�6�   �� 57   
   $��8��6   $��1��6    $Y��S/TrevyBurgess.Games.TrevyChess.ChessGameUI;component/Images/ChessPieces/Square1.jpg��6-   $
��Fill=�6�   �� 58   
   -   5        $��	RightRow8��58      $��9��6%   $��1��65   $	�� 8 ��6B   $��Center=�6M   $��Center=�6j   �� 5:   
   -   5        $��LeftRow7��5:      $��0��6$   $��2��64   $	�� 7 ��6A   $��Center=�6L   $��Center=�6i   �� 5;   
   $��1��6   $��2��6    $Y��S/TrevyBurgess.Games.TrevyChess.ChessGameUI;component/Images/ChessPieces/Square1.jpg��6-   $
��Fill=�6�   �� 5<   
   $��2��6   $��2��6    $Y��S/TrevyBurgess.Games.TrevyChess.ChessGameUI;component/Images/ChessPieces/Square2.jpg��6-   $
��Fill=�6�   �� 5=   
   $��3��6   $��2��6    $Y��S/TrevyBurgess.Games.TrevyChess.ChessGameUI;component/Images/ChessPieces/Square1.jpg��6-   $
��Fill=�6�   �� 5>   
   $��4��6   $��2��6    $Y��S/TrevyBurgess.Games.TrevyChess.ChessGameUI;component/Images/ChessPieces/Square2.jpg��6-   $
��Fill=�6�   �� 5?   
   $��5��6   $��2��6    $Y��S/TrevyBurgess.Games.TrevyChess.ChessGameUI;component/Images/ChessPieces/Square1.jpg��6-   $
��Fill=�6�   �� 5@   
   $��6��6   $��2��6    $Y��S/TrevyBurgess.Games.TrevyChess.ChessGameUI;component/Images/ChessPieces/Square2.jpg��6-   $
��Fill=�6�   �� 5A   
   $��7��6   $��2��6    $Y��S/TrevyBurgess.Games.TrevyChess.ChessGameUI;component/Images/ChessPieces/Square1.jpg��6-   $
��Fill=�6�   �� 5B   
   $��8��6   $��2��6    $Y��S/TrevyBurgess.Games.TrevyChess.ChessGameUI;component/Images/ChessPieces/Square2.jpg��6-   $
��Fill=�6�   �� 5C   
   -   5        $��	RightRow7��5C      $��9��6%   $��2��65   $	�� 7 ��6B   $��Center=�6M   $��Center=�6j   �� 5E   
   -   5        $��LeftRow6��5E      $��0��6$   $��3��64   $	�� 6 ��6A   $��Center=�6L   $��Center=�6i   �� 5F   
   $��1��6   $��3��6    $Y��S/TrevyBurgess.Games.TrevyChess.ChessGameUI;component/Images/ChessPieces/Square2.jpg��6-   $
��Fill=�6�   �� 5G   
   $��2��6   $��3��6    $Y��S/TrevyBurgess.Games.TrevyChess.ChessGameUI;component/Images/ChessPieces/Square1.jpg��6-   $
��Fill=�6�   �� 5H   
   $��3��6   $��3��6    $Y��S/TrevyBurgess.Games.TrevyChess.ChessGameUI;component/Images/ChessPieces/Square2.jpg��6-   $
��Fill=�6�   �� 5I   
   $��4��6   $��3��6    $Y��S/TrevyBurgess.Games.TrevyChess.ChessGameUI;component/Images/ChessPieces/Square1.jpg��6-   $
��Fill=�6�   �� 5J   
   $��5��6   $��3��6    $Y��S/TrevyBurgess.Games.TrevyChess.ChessGameUI;component/Images/ChessPieces/Square2.jpg��6-   $
��Fill=�6�   �� 5K   
   $��6��6   $��3��6    $Y��S/TrevyBurgess.Games.TrevyChess.ChessGameUI;component/Images/ChessPieces/Square1.jpg��6-   $
��Fill=�6�   �� 5L   
   $��7��6   $��3��6    $Y��S/TrevyBurgess.Games.TrevyChess.ChessGameUI;component/Images/ChessPieces/Square2.jpg��6-   $
��Fill=�6�   �� 5M   
   $��8��6   $��3��6    $Y��S/TrevyBurgess.Games.TrevyChess.ChessGameUI;component/Images/ChessPieces/Square1.jpg��6-   $
��Fill=�6�   �� 5N   
   -   5        $��	RightRow6��5N      $��9��6%   $��3��65   $	�� 6 ��6B   $��Center=�6M   $��Center=�6j   �� 5P   
   -   5        $��LeftRow5��5P      $��0��6$   $��4��64   $	�� 5 ��6A   $��Center=�6L   $��Center=�6i   �� 5Q   
   $��1��6   $��4��6    $Y��S/TrevyBurgess.Games.TrevyChess.ChessGameUI;component/Images/ChessPieces/Square1.jpg��6-   $
��Fill=�6�   �� 5R   
   $��2��6   $��4��6    $Y��S/TrevyBurgess.Games.TrevyChess.ChessGameUI;component/Images/ChessPieces/Square2.jpg��6-   $
��Fill=�6�   �� 5S   
   $��3��6   $��4��6    $Y��S/TrevyBurgess.Games.TrevyChess.ChessGameUI;component/Images/ChessPieces/Square1.jpg��6-   $
��Fill=�6�   �� 5T   
   $��4��6   $��4��6    $Y��S/TrevyBurgess.Games.TrevyChess.ChessGameUI;component/Images/ChessPieces/Square2.jpg��6-   $
��Fill=�6�   �� 5U   
   $��5��6   $��4��6    $Y��S/TrevyBurgess.Games.TrevyChess.ChessGameUI;component/Images/ChessPieces/Square1.jpg��6-   $
��Fill=�6�   �� 5V   
   $��6��6   $��4��6    $Y��S/TrevyBurgess.Games.TrevyChess.ChessGameUI;component/Images/ChessPieces/Square2.jpg��6-   $
��Fill=�6�   �� 5W   
   $��7��6   $��4��6    $Y��S/TrevyBurgess.Games.TrevyChess.ChessGameUI;component/Images/ChessPieces/Square1.jpg��6-   $
��Fill=�6�   �� 5X   
   $��8��6   $��4��6    $Y��S/TrevyBurgess.Games.TrevyChess.ChessGameUI;component/Images/ChessPieces/Square2.jpg��6-   $
��Fill=�6�   �� 5Y   
   -   5        $��	RightRow5��5Y      $��9��6%   $��4��65   $	�� 5 ��6B   $��Center=�6M   $��Center=�6j   �� 5[   
   -   5        $��LeftRow4��5[      $��0��6$   $��5��64   $	�� 4 ��6A   $��Center=�6L   $��Center=�6i   �� 5\   
   $��1��6   $��5��6    $Y��S/TrevyBurgess.Games.TrevyChess.ChessGameUI;component/Images/ChessPieces/Square2.jpg��6-   $
��Fill=�6�   �� 5]   
   $��2��6   $��5��6    $Y��S/TrevyBurgess.Games.TrevyChess.ChessGameUI;component/Images/ChessPieces/Square1.jpg��6-   $
��Fill=�6�   �� 5^   
   $��3��6   $��5��6    $Y��S/TrevyBurgess.Games.TrevyChess.ChessGameUI;component/Images/ChessPieces/Square2.jpg��6-   $
��Fill=�6�   �� 5_   
   $��4��6   $��5��6    $Y��S/TrevyBurgess.Games.TrevyChess.ChessGameUI;component/Images/ChessPieces/Square1.jpg��6-   $
��Fill=�6�   �� 5`   
   $��5��6   $��5��6    $Y��S/TrevyBurgess.Games.TrevyChess.ChessGameUI;component/Images/ChessPieces/Square2.jpg��6-   $
��Fill=�6�   �� 5a   
   $��6��6   $��5��6    $Y��S/TrevyBurgess.Games.TrevyChess.ChessGameUI;component/Images/ChessPieces/Square1.jpg��6-   $
��Fill=�6�   �� 5b   
   $��7��6   $��5��6    $Y��S/TrevyBurgess.Games.TrevyChess.ChessGameUI;component/Images/ChessPieces/Square2.jpg��6-   $
��Fill=�6�   �� 5c   
   $��8��6   $��5��6    $Y��S/TrevyBurgess.Games.TrevyChess.ChessGameUI;component/Images/ChessPieces/Square1.jpg��6-   $
��Fill=�6�   �� 5d   
   -   5        $��	RightRow4��5d      $��9��6%   $��5��65   $	�� 4 ��6B   $��Center=�6M   $��Center=�6j   �� 5f   
   -   5        $��LeftRow3��5f      $��0��6$   $��6��64   $	�� 3 ��6A   $��Center=�6L   $��Center=�6i   �� 5g   
   $��1��6   $��6��6    $Y��S/TrevyBurgess.Games.TrevyChess.ChessGameUI;component/Images/ChessPieces/Square1.jpg��6-   $
��Fill=�6�   �� 5h   
   $��2��6   $��6��6    $Y��S/TrevyBurgess.Games.TrevyChess.ChessGameUI;component/Images/ChessPieces/Square2.jpg��6-   $
��Fill=�6�   �� 5i   
   $��3��6   $��6��6    $Y��S/TrevyBurgess.Games.TrevyChess.ChessGameUI;component/Images/ChessPieces/Square1.jpg��6-   $
��Fill=�6�   �� 5j   
   $��4��6   $��6��6    $Y��S/TrevyBurgess.Games.TrevyChess.ChessGameUI;component/Images/ChessPieces/Square2.jpg��6-   $
��Fill=�6�   �� 5k   
   $��5��6   $��6��6    $Y��S/TrevyBurgess.Games.TrevyChess.ChessGameUI;component/Images/ChessPieces/Square1.jpg��6-   $
��Fill=�6�   �� 5l   
   $��6��6   $��6��6    $Y��S/TrevyBurgess.Games.TrevyChess.ChessGameUI;component/Images/ChessPieces/Square2.jpg��6-   $
��Fill=�6�   �� 5m   
   $��7��6   $��6��6    $Y��S/TrevyBurgess.Games.TrevyChess.ChessGameUI;component/Images/ChessPieces/Square1.jpg��6-   $
��Fill=�6�   �� 5n   
   $��8��6   $��6��6    $Y��S/TrevyBurgess.Games.TrevyChess.ChessGameUI;component/Images/ChessPieces/Square2.jpg��6-   $
��Fill=�6�   �� 5o   
   -   5        $��	RightRow3��5o      $��9��6%   $��6��65   $	�� 3 ��6B   $��Center=�6M   $��Center=�6j   �� 5q   
   -   5        $��LeftRow2��5q      $��0��6$   $��7��64   $	�� 2 ��6A   $��Center=�6L   $��Center=�6i   �� 5r   
   $��1��6   $��7��6    $Y��S/TrevyBurgess.Games.TrevyChess.ChessGameUI;component/Images/ChessPieces/Square2.jpg��6-   $
��Fill=�6�   �� 5s   
   $��2��6   $��7��6    $Y��S/TrevyBurgess.Games.TrevyChess.ChessGameUI;component/Images/ChessPieces/Square1.jpg��6-   $
��Fill=�6�   �� 5t   
   $��3��6   $��7��6    $Y��S/TrevyBurgess.Games.TrevyChess.ChessGameUI;component/Images/ChessPieces/Square2.jpg��6-   $
��Fill=�6�   �� 5u   
   $��4��6   $��7��6    $Y��S/TrevyBurgess.Games.TrevyChess.ChessGameUI;component/Images/ChessPieces/Square1.jpg��6-   $
��Fill=�6�   �� 5v   
   $��5��6   $��7��6    $Y��S/TrevyBurgess.Games.TrevyChess.ChessGameUI;component/Images/ChessPieces/Square2.jpg��6-   $
��Fill=�6�   �� 5w   
   $��6��6   $��7��6    $Y��S/TrevyBurgess.Games.TrevyChess.ChessGameUI;component/Images/ChessPieces/Square1.jpg��6-   $
��Fill=�6�   �� 5x   
   $��7��6   $��7��6    $Y��S/TrevyBurgess.Games.TrevyChess.ChessGameUI;component/Images/ChessPieces/Square2.jpg��6-   $
��Fill=�6�   �� 5y   
   $��8��6   $��7��6    $Y��S/TrevyBurgess.Games.TrevyChess.ChessGameUI;component/Images/ChessPieces/Square1.jpg��6-   $
��Fill=�6�   �� 5z   
   -   5        $��	RightRow2��5z      $��9��6%   $��7��65   $	�� 2 ��6B   $��Center=�6M   $��Center=�6j   �� 5|   
   -   5        $��LeftRow1��5|      $��0��6$   $��8��64   $	�� 1 ��6A   $��Center=�6L   $��Center=�6i   �� 5}   
   $��1��6   $��8��6    $Y��S/TrevyBurgess.Games.TrevyChess.ChessGameUI;component/Images/ChessPieces/Square1.jpg��6-   $
��Fill=�6�   �� 5~   
   $��2��6   $��8��6    $Y��S/TrevyBurgess.Games.TrevyChess.ChessGameUI;component/Images/ChessPieces/Square2.jpg��6-   $
��Fill=�6�   �� 5   
   $��3��6   $��8��6    $Y��S/TrevyBurgess.Games.TrevyChess.ChessGameUI;component/Images/ChessPieces/Square1.jpg��6-   $
��Fill=�6�   �� 5�   
   $��4��6   $��8��6    $Y��S/TrevyBurgess.Games.TrevyChess.ChessGameUI;component/Images/ChessPieces/Square2.jpg��6-   $
��Fill=�6�   �� 5�   
   $��5��6   $��8��6    $Y��S/TrevyBurgess.Games.TrevyChess.ChessGameUI;component/Images/ChessPieces/Square1.jpg��6-   $
��Fill=�6�   �� 5�   
   $��6��6   $��8��6    $Y��S/TrevyBurgess.Games.TrevyChess.ChessGameUI;component/Images/ChessPieces/Square2.jpg��6-   $
��Fill=�6�   �� 5�   
   $��7��6   $��8��6    $Y��S/TrevyBurgess.Games.TrevyChess.ChessGameUI;component/Images/ChessPieces/Square1.jpg��6-   $
��Fill=�6�   �� 5�   
   $��8��6   $��8��6    $Y��S/TrevyBurgess.Games.TrevyChess.ChessGameUI;component/Images/ChessPieces/Square2.jpg��6-   $
��Fill=�6�   �� 5�   
   -   5        $��	RightRow1��5�      $��9��6%   $��8��65   $	�� 1 ��6B   $��Center=�6M   $��Center=�6j   �� 5�   
   -   5        $��
BottomCol1��5�      $��1��6&   $��9��66   $	�� A ��6C   $��Center=�6N   $��Center=�6k   �� 5�   
   -   5        $��
BottomCol2��5�      $��2��6&   $��9��66   $	�� B ��6C   $��Center=�6N   $��Center=�6k   �� 5�   
   -   5        $��
BottomCol3��5�      $��3��6&   $��9��66   $	�� C ��6C   $��Center=�6N   $��Center=�6k   �� 5�   
   -   5        $��
BottomCol4��5�      $��4��6&   $��9��66   $	�� D ��6C   $��Center=�6N   $��Center=�6k   �� 5�   
   -   5        $��
BottomCol5��5�      $��5��6&   $��9��66   $	�� E ��6C   $��Center=�6N   $��Center=�6k   �� 5�   
   -   5        $��
BottomCol6��5�      $��6��6&   $��9��66   $	�� F ��6C   $��Center=�6N   $��Center=�6k   �� 5�   
   -    5        $��
BottomCol7��5�      $��7��6&   $��9��66   $	�� G ��6C   $��Center=�6N   $��Center=�6k   �� 5�   
   -!   5        $��
BottomCol8��5�      $��8��6&   $��9��66   $	�� H ��6C   $��Center=�6N   $��Center=�6k   E   ?TrevyBurgess.Games.TrevyChess.ChessGameUI.Controls.ChessPieceUi  5�   
   -"   5          Name$ Black_Rook1��5�   I      
PieceColor$ Black=�6%      	PieceType$
 Rook=�68      
PieceImage$X R/TrevyBurgess.Games.TrevyChess.ChessGameUI;component/Images/ChessPieces/B_Rook.gif��5�   $      PieceColumnPosition$ A=�5�   $   	   PieceRowPosition$	 R8=�6<     5�   
   -#   5        $ Black_Knight1��5�   J   $ Black=�6&   $
 Rook=�69   $Z T/TrevyBurgess.Games.TrevyChess.ChessGameUI;component/Images/ChessPieces/B_Knight.gif��5�   $   $ B=�5�   $   $	 R8=�6<     5�   
   -$   5        $ Black_Bishop1��5�   J   $ Black=�6&   $
 Rook=�69   $Z T/TrevyBurgess.Games.TrevyChess.ChessGameUI;component/Images/ChessPieces/B_Bishop.gif��5�   $   $ C=�5�   $   $	 R8=�6<     5�   
   -%   5        $ Black_Queen��5�   J   $ Black=�6&   $
 Rook=�69   $Y S/TrevyBurgess.Games.TrevyChess.ChessGameUI;component/Images/ChessPieces/B_Queen.gif��5�   $   $ D=�5�   $   $	 R8=�6<     5�   
   -&   5        $ 
Black_King��5�   J   $ Black=�6&   $
 Rook=�69   $X R/TrevyBurgess.Games.TrevyChess.ChessGameUI;component/Images/ChessPieces/B_King.gif��5�   $   $ E=�5�   $   $	 R8=�6<     5�   
   -'   5        $ Black_Bishop2��5�   J   $ Black=�6&   $
 Rook=�69   $Z T/TrevyBurgess.Games.TrevyChess.ChessGameUI;component/Images/ChessPieces/B_Bishop.gif��5�   $   $ F=�5�   $   $	 R8=�6<     5�   
   -(   5        $ Black_Knight2��5�   J   $ Black=�6&   $
 Rook=�69   $Z T/TrevyBurgess.Games.TrevyChess.ChessGameUI;component/Images/ChessPieces/B_Knight.gif��5�   $   $ G=�5�   $   $	 R8=�6<     5�   
   -)   5        $ Black_Rook2��5�   J   $ Black=�6&   $
 Rook=�69   $X R/TrevyBurgess.Games.TrevyChess.ChessGameUI;component/Images/ChessPieces/B_Rook.gif��5�   $   $ H=�5�   $   $	 R8=�6<     5�   
   -*   5        $ Black_Pawn1��5�   J   $ Black=�6&   $
 Rook=�69   $X R/TrevyBurgess.Games.TrevyChess.ChessGameUI;component/Images/ChessPieces/B_Pawn.gif��5�   $   $ A=�5�   $   $	 R7=�6<     5�   
   -+   5        $ Black_Pawn2��5�   J   $ Black=�6&   $
 Rook=�69   $X R/TrevyBurgess.Games.TrevyChess.ChessGameUI;component/Images/ChessPieces/B_Pawn.gif��5�   $   $ B=�5�   $   $	 R7=�6<     5�   
   -,   5        $ Black_Pawn3��5�   J   $ Black=�6&   $
 Rook=�69   $X R/TrevyBurgess.Games.TrevyChess.ChessGameUI;component/Images/ChessPieces/B_Pawn.gif��5�   $   $ C=�5�   $   $	 R7=�6<     5�   
   --   5        $ Black_Pawn4��5�   J   $ Black=�6&   $
 Rook=�69   $X R/TrevyBurgess.Games.TrevyChess.ChessGameUI;component/Images/ChessPieces/B_Pawn.gif��5�   $   $ D=�5�   $   $	 R7=�6<     5�   
   -.   5        $ Black_Pawn5��5�   J   $ Black=�6&   $
 Rook=�69   $X R/TrevyBurgess.Games.TrevyChess.ChessGameUI;component/Images/ChessPieces/B_Pawn.gif��5�   $   $ E=�5�   $   $	 R7=�6<     5�   
   -/   5        $ Black_Pawn6��5�   J   $ Black=�6&   $
 Rook=�69   $X R/TrevyBurgess.Games.TrevyChess.ChessGameUI;component/Images/ChessPieces/B_Pawn.gif��5�   $   $ F=�5�   $   $	 R7=�6<     5�   
   -0   5        $ Black_Pawn7��5�   J   $ Black=�6&   $
 Rook=�69   $X R/TrevyBurgess.Games.TrevyChess.ChessGameUI;component/Images/ChessPieces/B_Pawn.gif��5�   $   $ G=�5�   $   $	 R7=�6<     5�   
   -1   5        $ Black_Pawn8��5�   J   $ Black=�6&   $
 Rook=�69   $X R/TrevyBurgess.Games.TrevyChess.ChessGameUI;component/Images/ChessPieces/B_Pawn.gif��5�   $   $ H=�5�   $   $	 R7=�6<     5�   
   -2   5        $ White_Rook1��5�   J   $ White=�6&   $
 Rook=�69   $X R/TrevyBurgess.Games.TrevyChess.ChessGameUI;component/Images/ChessPieces/W_Rook.gif��5�   $   $ A=�5�   $   $	 R1=�6<     5�   
   -3   5        $ White_Knight1��5�   J   $ White=�6&   $
 Rook=�69   $Z T/TrevyBurgess.Games.TrevyChess.ChessGameUI;component/Images/ChessPieces/W_Knight.gif��5�   $   $ B=�5�   $   $	 R1=�6<     5�   
   -4   5        $ White_Bishop1��5�   J   $ White=�6&   $
 Rook=�69   $Z T/TrevyBurgess.Games.TrevyChess.ChessGameUI;component/Images/ChessPieces/W_Bishop.gif��5�   $   $ C=�5�   $   $	 R1=�6<     5�   
   -5   5        $ White_Queen��5�   J   $ White=�6&   $
 Rook=�69   $Y S/TrevyBurgess.Games.TrevyChess.ChessGameUI;component/Images/ChessPieces/W_Queen.gif��5�   $   $ D=�5�   $   $	 R1=�6<     5�   
   -6   5        $ 
White_King��5�   J   $ White=�6&   $
 Rook=�69   $X R/TrevyBurgess.Games.TrevyChess.ChessGameUI;component/Images/ChessPieces/W_King.gif��5�   $   $ E=�5�   $   $	 R1=�6<     5�   
   -7   5        $ White_Bishop2��5�   J   $ White=�6&   $
 Rook=�69   $Z T/TrevyBurgess.Games.TrevyChess.ChessGameUI;component/Images/ChessPieces/W_Bishop.gif��5�   $   $ F=�5�   $   $	 R1=�6<     5�   
   -8   5        $ White_Knight2��5�   J   $ White=�6&   $
 Rook=�69   $Z T/TrevyBurgess.Games.TrevyChess.ChessGameUI;component/Images/ChessPieces/W_Knight.gif��5�   $   $ G=�5�   $   $	 R1=�6<     5�   
   -9   5        $ White_Rook2��5�   J   $ White=�6&   $
 Rook=�69   $X R/TrevyBurgess.Games.TrevyChess.ChessGameUI;component/Images/ChessPieces/W_Rook.gif��5�   $   $ H=�5�   $   $	 R1=�6<     5�   
   -:   5        $ White_Pawn1��5�   J   $ White=�6&   $
 Rook=�69   $X R/TrevyBurgess.Games.TrevyChess.ChessGameUI;component/Images/ChessPieces/W_Pawn.gif��5�   $   $ A=�5�   $   $	 R2=�6<     5�   
   -;   5        $ White_Pawn2��5�   J   $ White=�6&   $
 Rook=�69   $X R/TrevyBurgess.Games.TrevyChess.ChessGameUI;component/Images/ChessPieces/W_Pawn.gif��5�   $   $ B=�5�   $   $	 R2=�6<     5�   
   -<   5        $ White_Pawn3��5�   J   $ White=�6&   $
 Rook=�69   $X R/TrevyBurgess.Games.TrevyChess.ChessGameUI;component/Images/ChessPieces/W_Pawn.gif��5�   $   $ C=�5�   $   $	 R2=�6<     5�   
   -=   5        $ White_Pawn4��5�   J   $ White=�6&   $
 Rook=�69   $X R/TrevyBurgess.Games.TrevyChess.ChessGameUI;component/Images/ChessPieces/W_Pawn.gif��5   $   $ D=�5  $   $	 R2=�6<     5  
   ->   5        $ White_Pawn5��5  J   $ White=�6&   $
 Rook=�69   $X R/TrevyBurgess.Games.TrevyChess.ChessGameUI;component/Images/ChessPieces/W_Pawn.gif��5  $   $ E=�5  $   $	 R2=�6<     5  
   -?   5        $ White_Pawn6��5  J   $ White=�6&   $
 Rook=�69   $X R/TrevyBurgess.Games.TrevyChess.ChessGameUI;component/Images/ChessPieces/W_Pawn.gif��5  $   $ F=�5	  $   $	 R2=�6<     5  
   -@   5        $ White_Pawn7��5  J   $ White=�6&   $
 Rook=�69   $X R/TrevyBurgess.Games.TrevyChess.ChessGameUI;component/Images/ChessPieces/W_Pawn.gif��5  $   $ G=�5  $   $	 R2=�6<     5  
   -A   5        $ White_Pawn8��5  J   $ White=�6&   $
 Rook=�69   $X R/TrevyBurgess.Games.TrevyChess.ChessGameUI;component/Images/ChessPieces/W_Pawn.gif��5  $   $ H=�5  $   $	 R2=�6<   5     5     