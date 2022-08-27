using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Node 
{
    public int GridX; // Position X di Array node
    public int GridY; // Position Y di Array node

    public bool IsObstacles; //beri tahu program jika simpul ini terhalang
    public Vector3 Position; //posisi dunia pada simpul ini

    public Node parent; //untuk algoritme a* akan menyimpan dari simpul mana asalnya sebelumnya sehingga dapat melacak jalur terpendek

    public int GCost; //biaya pindah ke kotak berikutnya
    public int HCost; //jarak ke tujuan dari simpul ini

    public int FCost { get { return GCost + HCost; } } //quick get function untuk menambahkan g cost h cost dan karena kita tidak akan pernah mengedit f cost. kita tidak perlu mengatur fungsi

    public Node(bool a_IsObstacles,Vector3 a_pos,int a_GridX, int a_GridY) //Constructor
    {
        IsObstacles = a_IsObstacles; //beri tahu program jika simpul ini terhalang
        Position = a_pos; ///posisi dunia pada simpul ini
        GridX = a_GridX; //Position X di Array node
        GridY = a_GridY; // Position Y di Array node
    }
   
}
