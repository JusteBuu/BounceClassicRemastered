using System;
using UnityEngine;

namespace Systems
{
    public class HealthSystem
    {
        [SerializeField] private int _maxHealth = 5;
        [SerializeField] private int _currentHealth;
    
        public int CurrentHealth => _currentHealth;
        public int MaxHealth => _maxHealth;
    
        public event Action<int> OnHealthChanged;
    
        public void Initialize()
        {
            _currentHealth = _maxHealth;
        }
    
        public void ChangeHealth(int amount)
        {
            var newHealth = Mathf.Clamp(_currentHealth + amount, 0, _maxHealth);
            if (newHealth == _currentHealth) return;
            _currentHealth = newHealth;
            OnHealthChanged?.Invoke(_currentHealth);
        }
    
        public bool IsAtMaxHealth() => _currentHealth >= _maxHealth;
        public bool IsAlive() => _currentHealth > 0;
    }
}