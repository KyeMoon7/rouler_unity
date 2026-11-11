using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using extOSC;


public class OscProcess : MonoBehaviour
{
    // Start is called before the first frame update
    public extOSC.OSCReceiver oscReceiver;
    public extOSC.OSCTransmitter oscTransmitter;
    public Player player;
    public int betaInMin = 0;
    public int betaInMax = 1023;
    public float betaOutMin = 0.0f;
    public float betaOutMax = 1.0f;
    void Start()
    {

        oscReceiver.Bind("/enc/rot", TraiterMessageRot);

        oscReceiver.Bind("/enc/but", TraiterMessageBut);
    }

    // Update is called once per frame
    void Update()
    {

    }

    void TraiterMessageBut(OSCMessage message)
    {
        // DEBUG SECTION
        // Validez qu’il y a bien le nombre attendu d’arguments (1 dans l’exemple) :
        if (message.Values.Count != 1)
        {
            Debug.Log("Le message " + message.Address + " n’a pas le bon nombre d’arguments");
            return; // Quitte la fonction sans exécuter la suite
        }
        // Vérifiez que l’argument est du type attendu (`int` dans l’exemple) :
        if (message.Values[0].Type != OSCValueType.Int)
        {
            Debug.Log("Le premier argument du message " + message.Address + "n’est pas un entier");
            return; // Quitte la fonction sans exécuter la suite
        }

        // TRAITEMENT DE LA VALEUR
        // Recoit la valeur "message" et la met dans "valeur".
        int valeur = message.Values[0].IntValue;

        // Tu va probablement avoir une fonction qui demande une variable pour tirer.
        // Change "gameManager" par le nom du bon fichier et "Shoot" par la fonction !PUBLIC! qui tire.
        if (valeur == 1)
        {
            player.Jump();
        }
    }

    void TraiterMessageRot(OSCMessage message)
    {
        // DEBUG SECTION
        // Validez qu’il y a bien le nombre attendu d’arguments (1 dans l’exemple) :
        if (message.Values.Count != 1)
        {
            Debug.Log("Le message " + message.Address + " n’a pas le bon nombre d’arguments");
            return;   // Quitte la fonction sans exécuter la suite
        }
        // Vérifiez que l’argument est du type attendu (`int` dans l’exemple) :
        if (message.Values[0].Type != OSCValueType.Int)
        {
            Debug.Log("Le premier argument du message " + message.Address + "n’est pas un entier");
            return;   // Quitte la fonction sans exécuter la suite
        }
         int valeur = message.Values[0].IntValue;
        float ajustee = (
            ((float)valeur - betaInMin) / (betaInMax - betaInMin) * (betaOutMax - betaOutMin) + betaOutMin
        );
        player.AddTorque(ajustee);
    }
}

