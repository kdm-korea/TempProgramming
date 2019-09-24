#수치미분코드
#미분을 배열로 처리해야 하는 경우 사용

def numerical_gradient(f, x):
    h = 1e-4
    grad = np.zeros_like(x)
    
    for i in range(x.size):
        temp = x[i]
        x[i] = temp + h
        fx1 = f(x)
        
        x[i] = temp - h
        fx2 = f(x)
        
        grad[i] = (fx1 - fx2) / (2 * h)
        x[i] = temp
    return grad