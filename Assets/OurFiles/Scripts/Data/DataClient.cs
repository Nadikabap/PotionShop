using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Data
{
    public class DataClient : MonoBehaviour
    {
        [Header("Спрайты Клиентов")]
        public List<Sprite> clientSprite;

        [Header("Спрайты требуемых цветов")]
        public List<Sprite> requestSprite;
    }
}