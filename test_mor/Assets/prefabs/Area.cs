using UnityEngine;
using System.Collections;

public class Area {

    static float get2(Rect rect1,Rect rect2){
        return 0;
    }

    static float get1(Rect rect){
        return 0;
    }

    /*
     *#include <iostream>
#include <vector>
#include <algorithm>
 
void main()
{
    std::vector<float> X(4);
    std::vector<float> Y(4);
    std::cout<<"Enter coordinats first rectangle "; 
    std::cin>>X[0]>>Y[0]>>X[1]>>Y[1];
    std::cout<<"Enter coordinats second rectangle "; 
    std::cin>>X[2]>>Y[2]>>X[3]>>Y[3];
    
 
    if(X[0]>=X[1]||Y[1]>=Y[0]||X[2]>=X[3]||Y[3]>=Y[2])
        std::cout<<"Bad rectangle";
    else
    if(X[0]>=X[3]||X[2]>=X[1]||Y[3]>=Y[0]||Y[1]>=Y[2])//значит не пересекаются
    {
        std::cout<<"Disjoint";
    }
    else
    {//Если пересекаются - тогда найдем площадь
        sort(X.begin(),X.end());
        sort(Y.begin(),Y.end());
        float S=(X[2]-X[1])*(Y[2]-Y[1]);//Координаты внутреннего прямоугольника - будут 2 и 3 по величине
        std::cout<<"S="<<S;
    }    
}
     */
}
