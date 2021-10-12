using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Core.Interractables;

namespace FeedbackElements
{
    public class InterractableFeedback : MonoBehaviour
    {
        [SerializeField] Interractor interractor=null;

        [SerializeField] Material defaultMaterial;
        [SerializeField] Material activatedMaterial = null;
        [SerializeField] Material confirmMaterial = null;
        [SerializeField] Material refuseMaterial = null;


        Renderer ownRenderer;



        private void Awake()
        {

            ownRenderer = GetComponent<Renderer>();

            defaultMaterial = ownRenderer.material;


            if (activatedMaterial == null)
            {
                activatedMaterial = Resources.Load("Activated") as Material;
            }

            if (confirmMaterial == null)
            {
                confirmMaterial = Resources.Load("Confirm") as Material;
            }

            if (refuseMaterial == null)
            {
                refuseMaterial = Resources.Load("Refuse") as Material;
            }

            interractor.OnClientActivated += ClientActivate;
            interractor.OnClientConfirm += ClientConfirm;
            interractor.OnClientDeactivate += ClientDeactivate;
            interractor.OnClientRefuse += ClientRefuseAction;
        }



        protected virtual void ClientActivate()
        {
            ownRenderer.material = activatedMaterial;
        }

        protected virtual void ClientConfirm()
        {
            ownRenderer.material = confirmMaterial;
        }

        protected virtual void ClientDeactivate()
        {
            ownRenderer.material = defaultMaterial;
        }

        protected virtual void ClientRefuseAction()
        {
            ownRenderer.material = refuseMaterial;
        }
    }
}