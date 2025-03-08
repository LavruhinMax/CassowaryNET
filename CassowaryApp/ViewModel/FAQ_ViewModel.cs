using CassowaryApp.Pages;
using CassowaryApp.Service;

namespace CassowaryApp.ViewModel
{
    public class FAQ_ViewModel
    {
        public List<faqGroup> Faq { get; set; }
        public FAQ_ViewModel()
        {
            Faq = new List<faqGroup>
            {
                new faqGroup
                {
                    group = "Общие вопросы",
                    questions = new List<questionAnswer>
                    {
                        new questionAnswer
                        {
                            question = "Как изменить личные данные в профиле?",
                            answer = "Перейдите в раздел 'Настройки' в личном кабинете, нажмите на кнопку редактирования и внесите изменения",
                        },
                        new questionAnswer
                        {
                            question = "Как восстановить доступ к личному кабинету, если забыл пароль?",
                            answer = "Обратитесь в службу поддержки, чтобы получить одноразовый пароль"
                        },
                        new questionAnswer
                        {
                            question = "Как перейти на другой тарифный план?",
                            answer = "В личном кабинете выберите раздел 'Мой тариф', найдите подходящий тариф и нажмите 'Выбрать'. Подтвердите смену"
                        }
                    }
                },
                new faqGroup
                {
                    group = "Оплата и доставка",
                    questions = new List<questionAnswer>
                    {
                        new questionAnswer
                        {
                            question = "Какие способы оплаты доступны?",
                            answer = "Мы принимаем оплату банковскими картами, через PayPal и юMoney"
                        },
                        new questionAnswer
                        {
                            question = "Как настроить автоплатеж?",
                            answer = "Автоплатеж настраивается автоматически при подтверждении способа оплаты"
                        },
                        new questionAnswer
                        {
                            question = "Сколько времени занимает доставка?",
                            answer = "Доставка занимает от 2 до 5 рабочих дней в зависимости от вашего региона"
                        }
                    }
                },
                new faqGroup
                {
                    group = "Техническая поддержка",
                    questions = new List<questionAnswer>
                    {
                        new questionAnswer
                        {
                            question = "Как я могу связаться с тех. поддержкой?",
                            answer = "Позвонив по номеру 8-800-257-58-80, написав в группе ВКонтакте или Telegram"
                        },
                        new questionAnswer
                        {
                            question = "Какой график работы поддержки?",
                            answer = "Наша поддержка работает с понедельника по пятницу с 9:00 до 18:00"
                        },
                        new questionAnswer
                        {
                            question = "Что делать, если интернет не работает?",
                            answer = "Проверьте кабель Ethernet на наличие повреждений, проверьте, плотно ли воткнут кабель в разъем, перезагрузите маршрутизатор"
                        },
                        new questionAnswer
                        {
                            question = "Как подключить Wi-Fi на новом устройстве?",
                            answer = "Включите Wi-Fi на устройстве, найдите вашу сеть в списке доступных, введите пароль от Wi-Fi"
                        },
                    }
                }
            };
        }
    }
}
