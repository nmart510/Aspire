using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Deck<T>
{
    List<T> deckList = new List<T>();
    List<T> discardList = new List<T>();
    public void Add(T card){
        deckList.Add(card);
    }
    public T Draw(){
        if (deckList.Count == 0 && discardList.Count == 0)
            return default(T);
        if (deckList.Count == 0) Shuffle();
        T top = deckList[0];
        deckList.RemoveAt(0);
        return top;
    }
    public List<T> Draw(int number){
        List<T> cards = new List<T>();
        for (int  i = 0; i < number; i++){
            T temp = Draw();
            if (temp != null)
                cards.Add(temp);
        }
        return cards;
    }
    public void Shuffle(){
        List<T> temp = new List<T>();
        while (deckList.Count > 0){
            temp.Add(deckList[0]);
            deckList.RemoveAt(0);
        } while (discardList.Count > 0){
            temp.Add(discardList[0]);
            discardList.RemoveAt(0);
        } while (temp.Count > 0){
            int num = Random.Range(0,temp.Count);
            deckList.Add(temp[num]);
            temp.RemoveAt(num);
        }
    }
    public T Peek(){
        if (deckList.Count == 0) return default(T);
        T top = deckList[0];
        return top;
    }
    public List<T> Peek(int number){
        List<T> cards = new List<T>();
        for (int  i = 0; i < number; i++){
            if (deckList.Count > i)
                cards.Add(deckList[i]);
        }
        return cards;
    }
    public void Shift(){
        if (deckList.Count > 1){
            deckList.Add(deckList[0]);
            deckList.RemoveAt(0);
        }
    }
    public void Discard(T card){
        discardList.Add(card);
    }
    public void Discard(List<T> cards){
        while (cards.Count > 0){
            discardList.Add(cards[0]);
            cards.RemoveAt(0);
        }
    }
    public int DeckCount(){
        return deckList.Count;
    }
    public int DiscardCount(){
        return discardList.Count;
    }
    public List<T> InspectDeck(){
        return deckList;
    }
    public List<T> InspectDiscard(){
        return discardList;
    }
    public void Remove(T card){
        deckList.Remove(card);
    }
    public T peekDiscardTop(){
        if (discardList.Count == 0) return default(T);
        else return discardList[discardList.Count-1];
    }
}
