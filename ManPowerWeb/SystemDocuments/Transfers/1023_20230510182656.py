#!/usr/bin/env python
# coding: utf-8

# In[1]:


import cv2 as cv
import numpy as np
import matplotlib.pyplot as plt

img = cv.imread('E:/IUP Lab Test/Input3.png', 0)

height, width = img.shape[:2]

print(f"Image width: {width} pixels")
print(f"Image height: {height} pixels")

output = np.zeros_like(img)

hist, bins = np.histogram(img.flatten(), 256, [0,256])
cdf = hist.cumsum()
cdf_normalized = cdf * hist.max() / cdf.max()

percentile_5th = np.percentile(img, 5)
percentile_95th = np.percentile(img, 95)

mini = percentile_5th
maxi = percentile_95th
mino = 0
maxo = 255

for i in range(height):
    for j in range(width):
        output_pixel = ((img[i,j] - mini) * ((maxo - mino) / (maxi - mini))) + mino
        output[i,j] = output_pixel

hist_input, bins_input = np.histogram(img.flatten(), 256, [0, 256])
hist_output, bins_output = np.histogram(output.flatten(), 256, [0, 256])

plt.subplot(2,2,1)
plt.imshow(img, cmap='gray')
plt.title('Input Image')
plt.subplot(2,2,2)
plt.imshow(output, cmap='gray')
plt.title('Output Image')
plt.subplot(2,2,3)
plt.hist(img.flatten(), 256, [0,256])
plt.title('Input Histogram (R)')
plt.subplot(2,2,4)
plt.hist(output.flatten(), 256, [0,256])
plt.title('Output Histogram (S)')
plt.show()

cv.waitKey(0)



# In[ ]:





# In[ ]:




