using Data;
using UnityEngine;
using Game_Logic.CardLogic;

namespace Game_Logic.Client
{
	public class CurrentClient : MonoBehaviour
    {
        [SerializeField] private GameObject _clientPrefab;
        [SerializeField] private GameObject _reqPrefab;
        [SerializeField] private DataClient _dataClient;

        private Sprite _clientSprite;
        private Sprite _reqSprite;

        private CardColor _main;
        private CardColor _added;

        private int _currentclient = 0;

        private void Start()
        {
            NextClient();
        }

        public void NextClient()
        {
            if (gameObject.transform.childCount > 0)
            {
                _currentclient++;
                if (_currentclient < 8)
                {
                    Destroy(gameObject.transform.GetChild(0).gameObject);
                }
                else
                {
                    //  Сюда выходит, если клиенты кончились
                    Debug.Log("А все");
                }
            }
            LoadClientIformationFromData();
            InstantiateClient();

        }

        private void LoadClientIformationFromData()
        {
            _clientSprite = _dataClient.clientSprite[Random.Range(0, _dataClient.clientSprite.Count)];
            // Добавить выбор спрайтов, если решим отдельные спрайты на цвета делать
            _reqSprite = _dataClient.requestSprite[0];
        }

        private void InstantiateClient()
        {
            GameObject client = Instantiate(_clientPrefab, new Vector3(gameObject.transform.position.x, gameObject.transform.position.y - 1.15f, 0), Quaternion.identity);
            GameObject mainReq = Instantiate(_reqPrefab, new Vector3(gameObject.transform.position.x, gameObject.transform.position.y, 0), Quaternion.identity);
            GameObject addReq = Instantiate(_reqPrefab, new Vector3(gameObject.transform.position.x, gameObject.transform.position.y, 0), Quaternion.identity);
            mainReq.transform.localScale = new Vector3(100, 100, 1);
            addReq.transform.localScale = new Vector3(80, 80, 1);
            mainReq.transform.SetParent(client.transform);
            addReq.transform.SetParent(client.transform);
            mainReq.transform.Translate(-200f, 500f, 1f);
            addReq.transform.Translate(-80f, 500f, 1f);
            client.transform.SetParent(gameObject.transform);
            client.transform.localScale = new Vector3(500, 800, 1);

            SetClientInformation(client, mainReq, addReq);
        }

        private void SetClientInformation(GameObject client, GameObject mainReq, GameObject addReq)
        {
            // Нужно будет переписать весь блок - вылгядит не очень
            SpriteRenderer clientImage = client.GetComponent<SpriteRenderer>();
            SpriteRenderer mainImage = mainReq.GetComponent<SpriteRenderer>();
            SpriteRenderer addImage = addReq.GetComponent<SpriteRenderer>();
            clientImage.sprite = _clientSprite;
            mainImage.sprite = _reqSprite;
            addImage.sprite = _reqSprite;
            switch (Random.Range(0, 2))
            {
                case 0:
                    clientImage.color = new Color(0, 0, 1, 1);
                    break;
                case 1:
                    clientImage.color = new Color(0, 1, 0, 1);
                    break;
                case 2:
                    clientImage.color = new Color(1, 0, 0, 1);
                    break;
            }
            Client reqs = this.GetComponent<CreateDay>().GetClient(_currentclient);
            switch (reqs.GetMain())
            {
                case CardColor.Red:
                    mainImage.color = new Color(1, 0, 0, 1);
                    _main = CardColor.Red;
                    break;
                case CardColor.Green:
                    mainImage.color = new Color(0, 1, 0, 1);
                    _main = CardColor.Green;
                    break;
                case CardColor.Blue:
                    mainImage.color = new Color(0, 0, 1, 1);
                    _main = CardColor.Blue;
                    break;
                case CardColor.Yellow:
                    mainImage.color = new Color(1, 1, 0, 1);
                    _main = CardColor.Yellow;
                    break;
                case CardColor.Black:
                    mainImage.color = new Color(0, 0, 0, 1);
                    _main = CardColor.Black;
                    break;
            }
            switch (reqs.GetAdd())
            {
                case CardColor.Red:
                    addImage.color = new Color(1, 0, 0, 1);
                    _added = CardColor.Red;
                    break;
                case CardColor.Green:
                    addImage.color = new Color(0, 1, 0, 1);
                    _added = CardColor.Green;
                    break;
                case CardColor.Blue:
                    addImage.color = new Color(0, 0, 1, 1);
                    _added = CardColor.Blue;
                    break;
                case CardColor.Yellow:
                    addImage.color = new Color(1, 1, 0, 1);
                    _added = CardColor.Yellow;
                    break;
                case CardColor.Black:
                    addImage.color = new Color(0, 0, 0, 1);
                    _added = CardColor.Black;
                    break;
            }
        }

        public CardColor GetMain() => _main;
        public CardColor GetAdded() => _added;
    }
}