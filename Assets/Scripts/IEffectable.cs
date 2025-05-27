public interface IEffectable
{
    // Это для статус эффекта,посмотри как реализовано https://www.youtube.com/watch?v=J2CFVjqEHpU&t
    // Пока не понял как применить для нашего проекта, а по сути логика статус эффекта должна быть тут реализована
    public void ApplyEffect(statusEffect data);
    public void RemoveEffect();

    public void IsEffect();
}
