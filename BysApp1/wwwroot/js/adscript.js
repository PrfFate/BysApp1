/* Modal */
#studentDetailsModal {
    position: fixed;
    top: 0;
    left: 0;
    width: 100 %;
    height: 100 %;
    background: rgba(0, 0, 0, 0.5);
    display: none;
    justify - content: center;
    align - items: center;
    z - index: 1000;
}

.modal - content {
    background: #fff;
    padding: 20px;
    border - radius: 8px;
    width: 60 %;
    max - width: 500px;
}

.modal - header {
    font - size: 1.5rem;
    font - weight: 600;
    margin - bottom: 20px;
}

.modal - body {
    font - size: 1.1rem;
}

.modal - footer {
    text - align: right;
    margin - top: 20px;
}

.close - modal {
    background: #ff4d4d;
    color: #fff;
    border: none;
    padding: 8px 15px;
    border - radius: 5px;
    cursor: pointer;
    transition: background 0.3s ease;
}

.close - modal:hover {
    background: #e60000;
}

/* Buton Animasyonu */
.selection - btn {
    transition: all 0.3s ease;
    border - radius: 30px;
}

.selection - btn:hover {
    transform: translateY(-5px) scale(1.05);
    background - color: #00509e;
    box - shadow: 0 6px 12px rgba(0, 0, 0, 0.2);
}

.selection - btn:active {
    transform: translateY(0);
    box - shadow: 0 4px 8px rgba(0, 0, 0, 0.1);
}


