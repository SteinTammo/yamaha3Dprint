# 1 "C:\\Users\\stein\\Downloads\\Yamaha3DPrint\\yamaha3Dprint\\ArduinoSensorIO\\ArduinoSensorIO\\ArduinoSensorIO.cpp"
# 1 "C:\\Program Files (x86)\\Arduino\\java\\bin//"
# 1 "<built-in>"
# 1 "<command-line>"
# 1 "C:\\Users\\stein\\Downloads\\Yamaha3DPrint\\yamaha3Dprint\\ArduinoSensorIO\\ArduinoSensorIO\\ArduinoSensorIO.cpp"
# 1 "C:\\Users\\stein\\Downloads\\Yamaha3DPrint\\yamaha3Dprint\\ArduinoSensorIO\\ArduinoSensorIO\\ArduinoSensorIO.h" 1
       
class ArduinoSensorIO
{

       
# 1 "C:\\Program Files (x86)\\Arduino\\hardware\\arduino\\avr\\cores\\arduino/Arduino.h" 1






















# 1 "c:\\program files (x86)\\arduino\\hardware\\tools\\avr\\avr\\include\\stdlib.h" 1 3

# 1 "c:\\program files (x86)\\arduino\\hardware\\tools\\avr\\avr\\include\\stdlib.h" 3





































# 48 "c:\\program files (x86)\\arduino\\hardware\\tools\\avr\\avr\\include\\stdlib.h" 3
# 1 "c:\\program files (x86)\\arduino\\hardware\\tools\\avr\\lib\\gcc\\avr\\7.3.0\\include\\stddef.h" 1 3 4



































# 46 "c:\\program files (x86)\\arduino\\hardware\\tools\\avr\\lib\\gcc\\avr\\7.3.0\\include\\stddef.h" 3 4

















# 92 "c:\\program files (x86)\\arduino\\hardware\\tools\\avr\\lib\\gcc\\avr\\7.3.0\\include\\stddef.h" 3 4












# 117 "c:\\program files (x86)\\arduino\\hardware\\tools\\avr\\lib\\gcc\\avr\\7.3.0\\include\\stddef.h" 3 4










# 165 "c:\\program files (x86)\\arduino\\hardware\\tools\\avr\\lib\\gcc\\avr\\7.3.0\\include\\stddef.h" 3 4




# 216 "c:\\program files (x86)\\arduino\\hardware\\tools\\avr\\lib\\gcc\\avr\\7.3.0\\include\\stddef.h" 3 4
typedef unsigned int size_t;
# 242 "c:\\program files (x86)\\arduino\\hardware\\tools\\avr\\lib\\gcc\\avr\\7.3.0\\include\\stddef.h" 3 4







# 283 "c:\\program files (x86)\\arduino\\hardware\\tools\\avr\\lib\\gcc\\avr\\7.3.0\\include\\stddef.h" 3 4










# 310 "c:\\program files (x86)\\arduino\\hardware\\tools\\avr\\lib\\gcc\\avr\\7.3.0\\include\\stddef.h" 3 4



# 362 "c:\\program files (x86)\\arduino\\hardware\\tools\\avr\\lib\\gcc\\avr\\7.3.0\\include\\stddef.h" 3 4




# 398 "c:\\program files (x86)\\arduino\\hardware\\tools\\avr\\lib\\gcc\\avr\\7.3.0\\include\\stddef.h" 3 4

# 49 "c:\\program files (x86)\\arduino\\hardware\\tools\\avr\\avr\\include\\stdlib.h" 2 3







extern "C" {













typedef struct {
 int quot; 
 int rem; 
} div_t;


typedef struct {
 long quot; 
 long rem; 
} ldiv_t;


typedef int (*__compar_fn_t)(const void *, const void *);
# 112 "c:\\program files (x86)\\arduino\\hardware\\tools\\avr\\avr\\include\\stdlib.h" 3




extern void abort(void) __attribute__((__noreturn__));




extern int abs(int __i) __attribute__((__const__));








extern long labs(long __i) __attribute__((__const__));






















extern void *bsearch(const void *__key, const void *__base, size_t __nmemb,
       size_t __size, int (*__compar)(const void *, const void *));







extern div_t div(int __num, int __denom) __asm__("__divmodhi4") __attribute__((__const__));





extern ldiv_t ldiv(long __num, long __denom) __asm__("__divmodsi4") __attribute__((__const__));
















extern void qsort(void *__base, size_t __nmemb, size_t __size,
    __compar_fn_t __compar);































extern long strtol(const char *__nptr, char **__endptr, int __base);

































extern unsigned long strtoul(const char *__nptr, char **__endptr, int __base);











extern long atol(const char *__s) __attribute__((__pure__));











extern int atoi(const char *__s) __attribute__((__pure__));











extern void exit(int __status) __attribute__((__noreturn__));











extern void *malloc(size_t __size) __attribute__((__malloc__));






extern void free(void *__ptr);




extern size_t __malloc_margin;




extern char *__malloc_heap_start;




extern char *__malloc_heap_end;






extern void *calloc(size_t __nele, size_t __size) __attribute__((__malloc__));


















extern void *realloc(void *__ptr, size_t __size) __attribute__((__malloc__));

extern double strtod(const char *__nptr, char **__endptr);










extern double atof(const char *__nptr);





















extern int rand(void);



extern void srand(unsigned int __seed);






extern int rand_r(unsigned long *__ctx);

































extern __inline__ __attribute__((__gnu_inline__))
char *itoa (int __val, char *__s, int __radix)
{
    if (!__builtin_constant_p (__radix)) {
 extern char *__itoa (int, char *, int);
 return __itoa (__val, __s, __radix);
    } else if (__radix < 2 || __radix > 36) {
 *__s = 0;
 return __s;
    } else {
 extern char *__itoa_ncheck (int, char *, unsigned char);
 return __itoa_ncheck (__val, __s, __radix);
    }
}































extern __inline__ __attribute__((__gnu_inline__))
char *ltoa (long __val, char *__s, int __radix)
{
    if (!__builtin_constant_p (__radix)) {
 extern char *__ltoa (long, char *, int);
 return __ltoa (__val, __s, __radix);
    } else if (__radix < 2 || __radix > 36) {
 *__s = 0;
 return __s;
    } else {
 extern char *__ltoa_ncheck (long, char *, unsigned char);
 return __ltoa_ncheck (__val, __s, __radix);
    }
}





























extern __inline__ __attribute__((__gnu_inline__))
char *utoa (unsigned int __val, char *__s, int __radix)
{
    if (!__builtin_constant_p (__radix)) {
 extern char *__utoa (unsigned int, char *, int);
 return __utoa (__val, __s, __radix);
    } else if (__radix < 2 || __radix > 36) {
 *__s = 0;
 return __s;
    } else {
 extern char *__utoa_ncheck (unsigned int, char *, unsigned char);
 return __utoa_ncheck (__val, __s, __radix);
    }
}




























extern __inline__ __attribute__((__gnu_inline__))
char *ultoa (unsigned long __val, char *__s, int __radix)
{
    if (!__builtin_constant_p (__radix)) {
 extern char *__ultoa (unsigned long, char *, int);
 return __ultoa (__val, __s, __radix);
    } else if (__radix < 2 || __radix > 36) {
 *__s = 0;
 return __s;
    } else {
 extern char *__ultoa_ncheck (unsigned long, char *, unsigned char);
 return __ultoa_ncheck (__val, __s, __radix);
    }
}


















extern long random(void);




extern void srandom(unsigned long __seed);







extern long random_r(unsigned long *__ctx);













































extern char *dtostre(double __val, char *__s, unsigned char __prec,
       unsigned char __flags);















extern char *dtostrf(double __val, signed char __width,
                     unsigned char __prec, char *__s);

















extern int atexit(void (*)(void));
extern int system (const char *);
extern char *getenv (const char *);



}
# 24 "C:\\Program Files (x86)\\Arduino\\hardware\\arduino\\avr\\cores\\arduino/Arduino.h" 2
# 1 "c:\\program files (x86)\\arduino\\hardware\\tools\\avr\\lib\\gcc\\avr\\7.3.0\\include\\stdbool.h" 1 3 4


























# 39 "c:\\program files (x86)\\arduino\\hardware\\tools\\avr\\lib\\gcc\\avr\\7.3.0\\include\\stdbool.h" 3 4

# 51 "c:\\program files (x86)\\arduino\\hardware\\tools\\avr\\lib\\gcc\\avr\\7.3.0\\include\\stdbool.h" 3 4

# 25 "C:\\Program Files (x86)\\Arduino\\hardware\\arduino\\avr\\cores\\arduino/Arduino.h" 2
# 1 "c:\\program files (x86)\\arduino\\hardware\\tools\\avr\\avr\\include\\string.h" 1 3













































# 1 "c:\\program files (x86)\\arduino\\hardware\\tools\\avr\\lib\\gcc\\avr\\7.3.0\\include\\stddef.h" 1 3 4



































# 46 "c:\\program files (x86)\\arduino\\hardware\\tools\\avr\\lib\\gcc\\avr\\7.3.0\\include\\stddef.h" 3 4

















# 92 "c:\\program files (x86)\\arduino\\hardware\\tools\\avr\\lib\\gcc\\avr\\7.3.0\\include\\stddef.h" 3 4












# 117 "c:\\program files (x86)\\arduino\\hardware\\tools\\avr\\lib\\gcc\\avr\\7.3.0\\include\\stddef.h" 3 4










# 165 "c:\\program files (x86)\\arduino\\hardware\\tools\\avr\\lib\\gcc\\avr\\7.3.0\\include\\stddef.h" 3 4




# 242 "c:\\program files (x86)\\arduino\\hardware\\tools\\avr\\lib\\gcc\\avr\\7.3.0\\include\\stddef.h" 3 4







# 362 "c:\\program files (x86)\\arduino\\hardware\\tools\\avr\\lib\\gcc\\avr\\7.3.0\\include\\stddef.h" 3 4




# 398 "c:\\program files (x86)\\arduino\\hardware\\tools\\avr\\lib\\gcc\\avr\\7.3.0\\include\\stddef.h" 3 4

# 47 "c:\\program files (x86)\\arduino\\hardware\\tools\\avr\\avr\\include\\string.h" 2 3
# 58 "c:\\program files (x86)\\arduino\\hardware\\tools\\avr\\avr\\include\\string.h" 3
extern "C" {































# 113 "c:\\program files (x86)\\arduino\\hardware\\tools\\avr\\avr\\include\\string.h" 3












extern int ffs(int __val) __attribute__((__const__));





extern int ffsl(long __val) __attribute__((__const__));





__extension__ extern int ffsll(long long __val) __attribute__((__const__));












extern void *memccpy(void *, const void *, int, size_t);











extern void *memchr(const void *, int, size_t) __attribute__((__pure__));

















extern int memcmp(const void *, const void *, size_t) __attribute__((__pure__));










extern void *memcpy(void *, const void *, size_t);











extern void *memmem(const void *, size_t, const void *, size_t) __attribute__((__pure__));









extern void *memmove(void *, const void *, size_t);











extern void *memrchr(const void *, int, size_t) __attribute__((__pure__));









extern void *memset(void *, int, size_t);












extern char *strcat(char *, const char *);













extern char *strchr(const char *, int) __attribute__((__pure__));











extern char *strchrnul(const char *, int) __attribute__((__pure__));












extern int strcmp(const char *, const char *) __attribute__((__pure__));

















extern char *strcpy(char *, const char *);














extern int strcasecmp(const char *, const char *) __attribute__((__pure__));












extern char *strcasestr(const char *, const char *) __attribute__((__pure__));










extern size_t strcspn(const char *__s, const char *__reject) __attribute__((__pure__));



















extern char *strdup(const char *s1);












extern size_t strlcat(char *, const char *, size_t);










extern size_t strlcpy(char *, const char *, size_t);










extern size_t strlen(const char *) __attribute__((__pure__));











extern char *strlwr(char *);










extern char *strncat(char *, const char *, size_t);











extern int strncmp(const char *, const char *, size_t) __attribute__((__pure__));














extern char *strncpy(char *, const char *, size_t);














extern int strncasecmp(const char *, const char *, size_t) __attribute__((__pure__));













extern size_t strnlen(const char *, size_t) __attribute__((__pure__));












extern char *strpbrk(const char *__s, const char *__accept) __attribute__((__pure__));













extern char *strrchr(const char *, int) __attribute__((__pure__));









extern char *strrev(char *);

















extern char *strsep(char **, const char *);










extern size_t strspn(const char *__s, const char *__accept) __attribute__((__pure__));












extern char *strstr(const char *, const char *) __attribute__((__pure__));


















extern char *strtok(char *, const char *);
















extern char *strtok_r(char *, const char *, char **);












extern char *strupr(char *);



extern int strcoll(const char *s1, const char *s2);
extern char *strerror(int errnum);
extern size_t strxfrm(char *dest, const char *src, size_t n);



}
# 26 "C:\\Program Files (x86)\\Arduino\\hardware\\arduino\\avr\\cores\\arduino/Arduino.h" 2
# 1 "c:\\program files (x86)\\arduino\\hardware\\tools\\avr\\avr\\include\\math.h" 1 3
















































































































# 121 "c:\\program files (x86)\\arduino\\hardware\\tools\\avr\\avr\\include\\math.h" 3
extern "C" {





extern double cos(double __x) __attribute__((__const__));





extern double sin(double __x) __attribute__((__const__));





extern double tan(double __x) __attribute__((__const__));






extern double fabs(double __x) __attribute__((__const__));






extern double fmod(double __x, double __y) __attribute__((__const__));














extern double modf(double __x, double *__iptr);


extern float modff (float __x, float *__iptr);




extern double sqrt(double __x) __attribute__((__const__));


extern float sqrtf (float) __attribute__((__const__));




extern double cbrt(double __x) __attribute__((__const__));










extern double hypot (double __x, double __y) __attribute__((__const__));







extern double square(double __x) __attribute__((__const__));






extern double floor(double __x) __attribute__((__const__));






extern double ceil(double __x) __attribute__((__const__));

















extern double frexp(double __x, int *__pexp);







extern double ldexp(double __x, int __exp) __attribute__((__const__));





extern double exp(double __x) __attribute__((__const__));





extern double cosh(double __x) __attribute__((__const__));





extern double sinh(double __x) __attribute__((__const__));





extern double tanh(double __x) __attribute__((__const__));







extern double acos(double __x) __attribute__((__const__));







extern double asin(double __x) __attribute__((__const__));






extern double atan(double __x) __attribute__((__const__));








extern double atan2(double __y, double __x) __attribute__((__const__));





extern double log(double __x) __attribute__((__const__));





extern double log10(double __x) __attribute__((__const__));





extern double pow(double __x, double __y) __attribute__((__const__));






extern int isnan(double __x) __attribute__((__const__));









extern int isinf(double __x) __attribute__((__const__));






__attribute__((__const__)) static inline int isfinite (double __x)
{
    unsigned char __exp;
    __asm__ (
 "mov	%0, %C1		\n\t"
 "lsl	%0		\n\t"
 "mov	%0, %D1		\n\t"
 "rol	%0		"
 : "=r" (__exp)
 : "r" (__x) );
    return __exp != 0xff;
}






__attribute__((__const__)) static inline double copysign (double __x, double __y)
{
    __asm__ (
 "bst	%D2, 7	\n\t"
 "bld	%D0, 7	"
 : "=r" (__x)
 : "0" (__x), "r" (__y) );
    return __x;
}









extern int signbit (double __x) __attribute__((__const__));






extern double fdim (double __x, double __y) __attribute__((__const__));








extern double fma (double __x, double __y, double __z) __attribute__((__const__));







extern double fmax (double __x, double __y) __attribute__((__const__));







extern double fmin (double __x, double __y) __attribute__((__const__));






extern double trunc (double __x) __attribute__((__const__));










extern double round (double __x) __attribute__((__const__));












extern long lround (double __x) __attribute__((__const__));













extern long lrint (double __x) __attribute__((__const__));



}



# 27 "C:\\Program Files (x86)\\Arduino\\hardware\\arduino\\avr\\cores\\arduino/Arduino.h" 2

# 1 "c:\\program files (x86)\\arduino\\hardware\\tools\\avr\\avr\\include\\avr\\pgmspace.h" 1 3























































































# 1 "c:\\program files (x86)\\arduino\\hardware\\tools\\avr\\avr\\include\\inttypes.h" 1 3




































# 1 "c:\\program files (x86)\\arduino\\hardware\\tools\\avr\\lib\\gcc\\avr\\7.3.0\\include\\stdint.h" 1 3 4
# 9 "c:\\program files (x86)\\arduino\\hardware\\tools\\avr\\lib\\gcc\\avr\\7.3.0\\include\\stdint.h" 3 4
# 1 "c:\\program files (x86)\\arduino\\hardware\\tools\\avr\\avr\\include\\stdint.h" 1 3 4























































# 64 "c:\\program files (x86)\\arduino\\hardware\\tools\\avr\\avr\\include\\stdint.h" 3 4

# 123 "c:\\program files (x86)\\arduino\\hardware\\tools\\avr\\avr\\include\\stdint.h" 3 4


typedef signed int int8_t __attribute__((__mode__(__QI__)));
typedef unsigned int uint8_t __attribute__((__mode__(__QI__)));
typedef signed int int16_t __attribute__ ((__mode__ (__HI__)));
typedef unsigned int uint16_t __attribute__ ((__mode__ (__HI__)));
typedef signed int int32_t __attribute__ ((__mode__ (__SI__)));
typedef unsigned int uint32_t __attribute__ ((__mode__ (__SI__)));

typedef signed int int64_t __attribute__((__mode__(__DI__)));
typedef unsigned int uint64_t __attribute__((__mode__(__DI__)));












typedef int16_t intptr_t;




typedef uint16_t uintptr_t;











typedef int8_t int_least8_t;




typedef uint8_t uint_least8_t;




typedef int16_t int_least16_t;




typedef uint16_t uint_least16_t;




typedef int32_t int_least32_t;




typedef uint32_t uint_least32_t;







typedef int64_t int_least64_t;






typedef uint64_t uint_least64_t;













typedef int8_t int_fast8_t;




typedef uint8_t uint_fast8_t;




typedef int16_t int_fast16_t;




typedef uint16_t uint_fast16_t;




typedef int32_t int_fast32_t;




typedef uint32_t uint_fast32_t;







typedef int64_t int_fast64_t;






typedef uint64_t uint_fast64_t;



















typedef int64_t intmax_t;




typedef uint64_t uintmax_t;






# 298 "c:\\program files (x86)\\arduino\\hardware\\tools\\avr\\avr\\include\\stdint.h" 3 4













# 328 "c:\\program files (x86)\\arduino\\hardware\\tools\\avr\\avr\\include\\stdint.h" 3 4
















































































































































































































































































# 615 "c:\\program files (x86)\\arduino\\hardware\\tools\\avr\\avr\\include\\stdint.h" 3 4









# 700 "c:\\program files (x86)\\arduino\\hardware\\tools\\avr\\avr\\include\\stdint.h" 3 4

# 10 "c:\\program files (x86)\\arduino\\hardware\\tools\\avr\\lib\\gcc\\avr\\7.3.0\\include\\stdint.h" 2 3 4
# 38 "c:\\program files (x86)\\arduino\\hardware\\tools\\avr\\avr\\include\\inttypes.h" 2 3







































typedef int32_t int_farptr_t;



typedef uint32_t uint_farptr_t;








































































# 173 "c:\\program files (x86)\\arduino\\hardware\\tools\\avr\\avr\\include\\inttypes.h" 3































































































































# 328 "c:\\program files (x86)\\arduino\\hardware\\tools\\avr\\avr\\include\\inttypes.h" 3










































































# 420 "c:\\program files (x86)\\arduino\\hardware\\tools\\avr\\avr\\include\\inttypes.h" 3
































































































# 539 "c:\\program files (x86)\\arduino\\hardware\\tools\\avr\\avr\\include\\inttypes.h" 3











# 89 "c:\\program files (x86)\\arduino\\hardware\\tools\\avr\\avr\\include\\avr\\pgmspace.h" 2 3
# 1 "c:\\program files (x86)\\arduino\\hardware\\tools\\avr\\lib\\gcc\\avr\\7.3.0\\include\\stddef.h" 1 3 4



































# 46 "c:\\program files (x86)\\arduino\\hardware\\tools\\avr\\lib\\gcc\\avr\\7.3.0\\include\\stddef.h" 3 4

















# 92 "c:\\program files (x86)\\arduino\\hardware\\tools\\avr\\lib\\gcc\\avr\\7.3.0\\include\\stddef.h" 3 4












# 117 "c:\\program files (x86)\\arduino\\hardware\\tools\\avr\\lib\\gcc\\avr\\7.3.0\\include\\stddef.h" 3 4










# 165 "c:\\program files (x86)\\arduino\\hardware\\tools\\avr\\lib\\gcc\\avr\\7.3.0\\include\\stddef.h" 3 4




# 242 "c:\\program files (x86)\\arduino\\hardware\\tools\\avr\\lib\\gcc\\avr\\7.3.0\\include\\stddef.h" 3 4







# 362 "c:\\program files (x86)\\arduino\\hardware\\tools\\avr\\lib\\gcc\\avr\\7.3.0\\include\\stddef.h" 3 4




# 398 "c:\\program files (x86)\\arduino\\hardware\\tools\\avr\\lib\\gcc\\avr\\7.3.0\\include\\stddef.h" 3 4

# 90 "c:\\program files (x86)\\arduino\\hardware\\tools\\avr\\avr\\include\\avr\\pgmspace.h" 2 3
# 1 "c:\\program files (x86)\\arduino\\hardware\\tools\\avr\\avr\\include\\avr\\io.h" 1 3


































































































# 1 "c:\\program files (x86)\\arduino\\hardware\\tools\\avr\\avr\\include\\avr\\sfr_defs.h" 1 3




















































































































# 125 "c:\\program files (x86)\\arduino\\hardware\\tools\\avr\\avr\\include\\avr\\sfr_defs.h" 3

# 1 "c:\\program files (x86)\\arduino\\hardware\\tools\\avr\\avr\\include\\inttypes.h" 1 3
































# 127 "c:\\program files (x86)\\arduino\\hardware\\tools\\avr\\avr\\include\\avr\\sfr_defs.h" 2 3
# 194 "c:\\program files (x86)\\arduino\\hardware\\tools\\avr\\avr\\include\\avr\\sfr_defs.h" 3

















# 219 "c:\\program files (x86)\\arduino\\hardware\\tools\\avr\\avr\\include\\avr\\sfr_defs.h" 3















































# 100 "c:\\program files (x86)\\arduino\\hardware\\tools\\avr\\avr\\include\\avr\\io.h" 2 3
# 272 "c:\\program files (x86)\\arduino\\hardware\\tools\\avr\\avr\\include\\avr\\io.h" 3
# 1 "c:\\program files (x86)\\arduino\\hardware\\tools\\avr\\avr\\include\\avr\\iom328p.h" 1 3



























































# 32 "c:\\program files (x86)\\arduino\\hardware\\tools\\avr\\avr\\include\\avr\\iom328p.h" 3





# 52 "c:\\program files (x86)\\arduino\\hardware\\tools\\avr\\avr\\include\\avr\\iom328p.h" 3

# 799 "c:\\program files (x86)\\arduino\\hardware\\tools\\avr\\avr\\include\\avr\\iom328p.h" 3


# 881 "c:\\program files (x86)\\arduino\\hardware\\tools\\avr\\avr\\include\\avr\\iom328p.h" 3

# 893 "c:\\program files (x86)\\arduino\\hardware\\tools\\avr\\avr\\include\\avr\\iom328p.h" 3




# 907 "c:\\program files (x86)\\arduino\\hardware\\tools\\avr\\avr\\include\\avr\\iom328p.h" 3

# 918 "c:\\program files (x86)\\arduino\\hardware\\tools\\avr\\avr\\include\\avr\\iom328p.h" 3















# 273 "c:\\program files (x86)\\arduino\\hardware\\tools\\avr\\avr\\include\\avr\\io.h" 2 3
# 715 "c:\\program files (x86)\\arduino\\hardware\\tools\\avr\\avr\\include\\avr\\io.h" 3
# 1 "c:\\program files (x86)\\arduino\\hardware\\tools\\avr\\avr\\include\\avr\\portpins.h" 1 3












































# 54 "c:\\program files (x86)\\arduino\\hardware\\tools\\avr\\avr\\include\\avr\\portpins.h" 3

# 64 "c:\\program files (x86)\\arduino\\hardware\\tools\\avr\\avr\\include\\avr\\portpins.h" 3

# 74 "c:\\program files (x86)\\arduino\\hardware\\tools\\avr\\avr\\include\\avr\\portpins.h" 3



# 119 "c:\\program files (x86)\\arduino\\hardware\\tools\\avr\\avr\\include\\avr\\portpins.h" 3

# 162 "c:\\program files (x86)\\arduino\\hardware\\tools\\avr\\avr\\include\\avr\\portpins.h" 3

# 205 "c:\\program files (x86)\\arduino\\hardware\\tools\\avr\\avr\\include\\avr\\portpins.h" 3

# 248 "c:\\program files (x86)\\arduino\\hardware\\tools\\avr\\avr\\include\\avr\\portpins.h" 3

# 291 "c:\\program files (x86)\\arduino\\hardware\\tools\\avr\\avr\\include\\avr\\portpins.h" 3

# 334 "c:\\program files (x86)\\arduino\\hardware\\tools\\avr\\avr\\include\\avr\\portpins.h" 3

# 377 "c:\\program files (x86)\\arduino\\hardware\\tools\\avr\\avr\\include\\avr\\portpins.h" 3

# 420 "c:\\program files (x86)\\arduino\\hardware\\tools\\avr\\avr\\include\\avr\\portpins.h" 3

# 463 "c:\\program files (x86)\\arduino\\hardware\\tools\\avr\\avr\\include\\avr\\portpins.h" 3

# 506 "c:\\program files (x86)\\arduino\\hardware\\tools\\avr\\avr\\include\\avr\\portpins.h" 3

# 716 "c:\\program files (x86)\\arduino\\hardware\\tools\\avr\\avr\\include\\avr\\io.h" 2 3

# 1 "c:\\program files (x86)\\arduino\\hardware\\tools\\avr\\avr\\include\\avr\\common.h" 1 3




































# 1 "c:\\program files (x86)\\arduino\\hardware\\tools\\avr\\avr\\include\\avr\\sfr_defs.h" 1 3

































# 38 "c:\\program files (x86)\\arduino\\hardware\\tools\\avr\\avr\\include\\avr\\common.h" 2 3































# 98 "c:\\program files (x86)\\arduino\\hardware\\tools\\avr\\avr\\include\\avr\\common.h" 3

# 108 "c:\\program files (x86)\\arduino\\hardware\\tools\\avr\\avr\\include\\avr\\common.h" 3

# 206 "c:\\program files (x86)\\arduino\\hardware\\tools\\avr\\avr\\include\\avr\\common.h" 3








# 224 "c:\\program files (x86)\\arduino\\hardware\\tools\\avr\\avr\\include\\avr\\common.h" 3

# 234 "c:\\program files (x86)\\arduino\\hardware\\tools\\avr\\avr\\include\\avr\\common.h" 3

# 244 "c:\\program files (x86)\\arduino\\hardware\\tools\\avr\\avr\\include\\avr\\common.h" 3

# 255 "c:\\program files (x86)\\arduino\\hardware\\tools\\avr\\avr\\include\\avr\\common.h" 3

# 265 "c:\\program files (x86)\\arduino\\hardware\\tools\\avr\\avr\\include\\avr\\common.h" 3

# 275 "c:\\program files (x86)\\arduino\\hardware\\tools\\avr\\avr\\include\\avr\\common.h" 3

# 285 "c:\\program files (x86)\\arduino\\hardware\\tools\\avr\\avr\\include\\avr\\common.h" 3

# 295 "c:\\program files (x86)\\arduino\\hardware\\tools\\avr\\avr\\include\\avr\\common.h" 3

# 305 "c:\\program files (x86)\\arduino\\hardware\\tools\\avr\\avr\\include\\avr\\common.h" 3

# 315 "c:\\program files (x86)\\arduino\\hardware\\tools\\avr\\avr\\include\\avr\\common.h" 3

# 718 "c:\\program files (x86)\\arduino\\hardware\\tools\\avr\\avr\\include\\avr\\io.h" 2 3

# 1 "c:\\program files (x86)\\arduino\\hardware\\tools\\avr\\avr\\include\\avr\\version.h" 1 3























































































# 720 "c:\\program files (x86)\\arduino\\hardware\\tools\\avr\\avr\\include\\avr\\io.h" 2 3






# 1 "c:\\program files (x86)\\arduino\\hardware\\tools\\avr\\avr\\include\\avr\\fuse.h" 1 3





























































































































































































































# 239 "c:\\program files (x86)\\arduino\\hardware\\tools\\avr\\avr\\include\\avr\\fuse.h" 3
typedef struct
{
    unsigned char low;
    unsigned char high;
    unsigned char extended;
} __fuse_t;
# 727 "c:\\program files (x86)\\arduino\\hardware\\tools\\avr\\avr\\include\\avr\\io.h" 2 3


# 1 "c:\\program files (x86)\\arduino\\hardware\\tools\\avr\\avr\\include\\avr\\lock.h" 1 3
























































































































































































# 197 "c:\\program files (x86)\\arduino\\hardware\\tools\\avr\\avr\\include\\avr\\lock.h" 3

# 730 "c:\\program files (x86)\\arduino\\hardware\\tools\\avr\\avr\\include\\avr\\io.h" 2 3
# 91 "c:\\program files (x86)\\arduino\\hardware\\tools\\avr\\avr\\include\\avr\\pgmspace.h" 2 3
# 106 "c:\\program files (x86)\\arduino\\hardware\\tools\\avr\\avr\\include\\avr\\pgmspace.h" 3










extern "C" {
# 386 "c:\\program files (x86)\\arduino\\hardware\\tools\\avr\\avr\\include\\avr\\pgmspace.h" 3









# 407 "c:\\program files (x86)\\arduino\\hardware\\tools\\avr\\avr\\include\\avr\\pgmspace.h" 3

# 616 "c:\\program files (x86)\\arduino\\hardware\\tools\\avr\\avr\\include\\avr\\pgmspace.h" 3









# 639 "c:\\program files (x86)\\arduino\\hardware\\tools\\avr\\avr\\include\\avr\\pgmspace.h" 3







































# 1048 "c:\\program files (x86)\\arduino\\hardware\\tools\\avr\\avr\\include\\avr\\pgmspace.h" 3













































































# 1146 "c:\\program files (x86)\\arduino\\hardware\\tools\\avr\\avr\\include\\avr\\pgmspace.h" 3












extern const void * memchr_P(const void *, int __val, size_t __len) __attribute__((__const__));













extern int memcmp_P(const void *, const void *, size_t) __attribute__((__pure__));






extern void *memccpy_P(void *, const void *, int __val, size_t);








extern void *memcpy_P(void *, const void *, size_t);






extern void *memmem_P(const void *, size_t, const void *, size_t) __attribute__((__pure__));











extern const void * memrchr_P(const void *, int __val, size_t __len) __attribute__((__const__));









extern char *strcat_P(char *, const char *);















extern const char * strchr_P(const char *, int __val) __attribute__((__const__));











extern const char * strchrnul_P(const char *, int __val) __attribute__((__const__));












extern int strcmp_P(const char *, const char *) __attribute__((__pure__));









extern char *strcpy_P(char *, const char *);
















extern int strcasecmp_P(const char *, const char *) __attribute__((__pure__));






extern char *strcasestr_P(const char *, const char *) __attribute__((__pure__));












extern size_t strcspn_P(const char *__s, const char * __reject) __attribute__((__pure__));















extern size_t strlcat_P (char *, const char *, size_t );












extern size_t strlcpy_P (char *, const char *, size_t );











extern size_t strnlen_P(const char *, size_t) __attribute__((__const__)); 










extern int strncmp_P(const char *, const char *, size_t) __attribute__((__pure__));


















extern int strncasecmp_P(const char *, const char *, size_t) __attribute__((__pure__));










extern char *strncat_P(char *, const char *, size_t);













extern char *strncpy_P(char *, const char *, size_t);














extern char *strpbrk_P(const char *__s, const char * __accept) __attribute__((__pure__));










extern const char * strrchr_P(const char *, int __val) __attribute__((__const__));



















extern char *strsep_P(char **__sp, const char * __delim);












extern size_t strspn_P(const char *__s, const char * __accept) __attribute__((__pure__));













extern char *strstr_P(const char *, const char *) __attribute__((__pure__));





















extern char *strtok_P(char *__s, const char * __delim);



















extern char *strtok_rP(char *__s, const char * __delim, char **__last);












extern size_t strlen_PF(uint_farptr_t src) __attribute__((__const__)); 















extern size_t strnlen_PF(uint_farptr_t src, size_t len) __attribute__((__const__)); 














extern void *memcpy_PF(void *dest, uint_farptr_t src, size_t len);














extern char *strcpy_PF(char *dest, uint_farptr_t src);



















extern char *strncpy_PF(char *dest, uint_farptr_t src, size_t len);















extern char *strcat_PF(char *dest, uint_farptr_t src);




















extern size_t strlcat_PF(char *dst, uint_farptr_t src, size_t siz);
















extern char *strncat_PF(char *dest, uint_farptr_t src, size_t len);















extern int strcmp_PF(const char *s1, uint_farptr_t s2) __attribute__((__pure__));
















extern int strncmp_PF(const char *s1, uint_farptr_t s2, size_t n) __attribute__((__pure__));















extern int strcasecmp_PF(const char *s1, uint_farptr_t s2) __attribute__((__pure__));

















extern int strncasecmp_PF(const char *s1, uint_farptr_t s2, size_t n) __attribute__((__pure__));















extern char *strstr_PF(const char *s1, uint_farptr_t s2);











extern size_t strlcpy_PF(char *dst, uint_farptr_t src, size_t siz);















extern int memcmp_PF(const void *, uint_farptr_t, size_t) __attribute__((__pure__));
# 1779 "c:\\program files (x86)\\arduino\\hardware\\tools\\avr\\avr\\include\\avr\\pgmspace.h" 3
extern size_t __strlen_P(const char *) __attribute__((__const__)); 
__attribute__((__always_inline__)) static __inline__ size_t strlen_P(const char * s);
static __inline__ size_t strlen_P(const char *s) {
  return __builtin_constant_p(__builtin_strlen(s))
     ? __builtin_strlen(s) : __strlen_P(s);
}



}
# 29 "C:\\Program Files (x86)\\Arduino\\hardware\\arduino\\avr\\cores\\arduino/Arduino.h" 2
# 1 "c:\\program files (x86)\\arduino\\hardware\\tools\\avr\\avr\\include\\avr\\io.h" 1 3






























































































# 30 "C:\\Program Files (x86)\\Arduino\\hardware\\arduino\\avr\\cores\\arduino/Arduino.h" 2
# 1 "c:\\program files (x86)\\arduino\\hardware\\tools\\avr\\avr\\include\\avr\\interrupt.h" 1 3





































# 1 "c:\\program files (x86)\\arduino\\hardware\\tools\\avr\\avr\\include\\avr\\io.h" 1 3






























































































# 39 "c:\\program files (x86)\\arduino\\hardware\\tools\\avr\\avr\\include\\avr\\interrupt.h" 2 3


























# 103 "c:\\program files (x86)\\arduino\\hardware\\tools\\avr\\avr\\include\\avr\\interrupt.h" 3

# 283 "c:\\program files (x86)\\arduino\\hardware\\tools\\avr\\avr\\include\\avr\\interrupt.h" 3

# 342 "c:\\program files (x86)\\arduino\\hardware\\tools\\avr\\avr\\include\\avr\\interrupt.h" 3

# 31 "C:\\Program Files (x86)\\Arduino\\hardware\\arduino\\avr\\cores\\arduino/Arduino.h" 2

# 1 "C:\\Program Files (x86)\\Arduino\\hardware\\arduino\\avr\\cores\\arduino/binary.h" 1

# 1 "C:\\Program Files (x86)\\Arduino\\hardware\\arduino\\avr\\cores\\arduino/binary.h"


















# 33 "C:\\Program Files (x86)\\Arduino\\hardware\\arduino\\avr\\cores\\arduino/Arduino.h" 2


extern "C"{


void yield(void);
# 87 "C:\\Program Files (x86)\\Arduino\\hardware\\arduino\\avr\\cores\\arduino/Arduino.h"

# 117 "C:\\Program Files (x86)\\Arduino\\hardware\\arduino\\avr\\cores\\arduino/Arduino.h"





typedef unsigned int word;



typedef bool boolean;
typedef uint8_t byte;

void init(void);
void initVariant(void);

int atexit(void (*func)()) __attribute__((weak));

void pinMode(uint8_t pin, uint8_t mode);
void digitalWrite(uint8_t pin, uint8_t val);
int digitalRead(uint8_t pin);
int analogRead(uint8_t pin);
void analogReference(uint8_t mode);
void analogWrite(uint8_t pin, int val);

unsigned long millis(void);
unsigned long micros(void);
void delay(unsigned long ms);
void delayMicroseconds(unsigned int us);
unsigned long pulseIn(uint8_t pin, uint8_t state, unsigned long timeout);
unsigned long pulseInLong(uint8_t pin, uint8_t state, unsigned long timeout);

void shiftOut(uint8_t dataPin, uint8_t clockPin, uint8_t bitOrder, uint8_t val);
uint8_t shiftIn(uint8_t dataPin, uint8_t clockPin, uint8_t bitOrder);

void attachInterrupt(uint8_t interruptNum, void (*userFunc)(void), int mode);
void detachInterrupt(uint8_t interruptNum);

void setup(void);
void loop(void);








extern const uint16_t 
# 164 "C:\\Program Files (x86)\\Arduino\\hardware\\arduino\\avr\\cores\\arduino/Arduino.h" 3
                     __attribute__((__progmem__)) 
# 164 "C:\\Program Files (x86)\\Arduino\\hardware\\arduino\\avr\\cores\\arduino/Arduino.h"
                             port_to_mode_PGM[];
extern const uint16_t 
# 165 "C:\\Program Files (x86)\\Arduino\\hardware\\arduino\\avr\\cores\\arduino/Arduino.h" 3
                     __attribute__((__progmem__)) 
# 165 "C:\\Program Files (x86)\\Arduino\\hardware\\arduino\\avr\\cores\\arduino/Arduino.h"
                             port_to_input_PGM[];
extern const uint16_t 
# 166 "C:\\Program Files (x86)\\Arduino\\hardware\\arduino\\avr\\cores\\arduino/Arduino.h" 3
                     __attribute__((__progmem__)) 
# 166 "C:\\Program Files (x86)\\Arduino\\hardware\\arduino\\avr\\cores\\arduino/Arduino.h"
                             port_to_output_PGM[];

extern const uint8_t 
# 168 "C:\\Program Files (x86)\\Arduino\\hardware\\arduino\\avr\\cores\\arduino/Arduino.h" 3
                    __attribute__((__progmem__)) 
# 168 "C:\\Program Files (x86)\\Arduino\\hardware\\arduino\\avr\\cores\\arduino/Arduino.h"
                            digital_pin_to_port_PGM[];

extern const uint8_t 
# 170 "C:\\Program Files (x86)\\Arduino\\hardware\\arduino\\avr\\cores\\arduino/Arduino.h" 3
                    __attribute__((__progmem__)) 
# 170 "C:\\Program Files (x86)\\Arduino\\hardware\\arduino\\avr\\cores\\arduino/Arduino.h"
                            digital_pin_to_bit_mask_PGM[];
extern const uint8_t 
# 171 "C:\\Program Files (x86)\\Arduino\\hardware\\arduino\\avr\\cores\\arduino/Arduino.h" 3
                    __attribute__((__progmem__)) 
# 171 "C:\\Program Files (x86)\\Arduino\\hardware\\arduino\\avr\\cores\\arduino/Arduino.h"
                            digital_pin_to_timer_PGM[];






# 227 "C:\\Program Files (x86)\\Arduino\\hardware\\arduino\\avr\\cores\\arduino/Arduino.h"
} 



# 1 "C:\\Program Files (x86)\\Arduino\\hardware\\arduino\\avr\\cores\\arduino/WCharacter.h" 1






















# 1 "c:\\program files (x86)\\arduino\\hardware\\tools\\avr\\avr\\include\\ctype.h" 1 3

# 1 "c:\\program files (x86)\\arduino\\hardware\\tools\\avr\\avr\\include\\ctype.h" 3






































# 48 "c:\\program files (x86)\\arduino\\hardware\\tools\\avr\\avr\\include\\ctype.h" 3
extern "C" {


















 






extern int isalnum(int __c) __attribute__((__const__));






extern int isalpha(int __c) __attribute__((__const__));






extern int isascii(int __c) __attribute__((__const__));





extern int isblank(int __c) __attribute__((__const__));





extern int iscntrl(int __c) __attribute__((__const__));





extern int isdigit(int __c) __attribute__((__const__));





extern int isgraph(int __c) __attribute__((__const__));





extern int islower(int __c) __attribute__((__const__));





extern int isprint(int __c) __attribute__((__const__));






extern int ispunct(int __c) __attribute__((__const__));







extern int isspace(int __c) __attribute__((__const__));





extern int isupper(int __c) __attribute__((__const__));






extern int isxdigit(int __c) __attribute__((__const__));




















extern int toascii(int __c) __attribute__((__const__));





extern int tolower(int __c) __attribute__((__const__));





extern int toupper(int __c) __attribute__((__const__));




}
# 24 "C:\\Program Files (x86)\\Arduino\\hardware\\arduino\\avr\\cores\\arduino/WCharacter.h" 2


# 25 "C:\\Program Files (x86)\\Arduino\\hardware\\arduino\\avr\\cores\\arduino/WCharacter.h"

inline boolean isAlphaNumeric(int c) __attribute__((always_inline));
inline boolean isAlpha(int c) __attribute__((always_inline));
inline boolean isAscii(int c) __attribute__((always_inline));
inline boolean isWhitespace(int c) __attribute__((always_inline));
inline boolean isControl(int c) __attribute__((always_inline));
inline boolean isDigit(int c) __attribute__((always_inline));
inline boolean isGraph(int c) __attribute__((always_inline));
inline boolean isLowerCase(int c) __attribute__((always_inline));
inline boolean isPrintable(int c) __attribute__((always_inline));
inline boolean isPunct(int c) __attribute__((always_inline));
inline boolean isSpace(int c) __attribute__((always_inline));
inline boolean isUpperCase(int c) __attribute__((always_inline));
inline boolean isHexadecimalDigit(int c) __attribute__((always_inline));
inline int toAscii(int c) __attribute__((always_inline));
inline int toLowerCase(int c) __attribute__((always_inline));
inline int toUpperCase(int c)__attribute__((always_inline));




inline boolean isAlphaNumeric(int c)
{
  return ( isalnum(c) == 0 ? false : true);
}




inline boolean isAlpha(int c)
{
  return ( isalpha(c) == 0 ? false : true);
}




inline boolean isAscii(int c)
{
  return ( isascii (c) == 0 ? false : true);
}



inline boolean isWhitespace(int c)
{
  return ( isblank (c) == 0 ? false : true);
}



inline boolean isControl(int c)
{
  return ( iscntrl (c) == 0 ? false : true);
}



inline boolean isDigit(int c)
{
  return ( isdigit (c) == 0 ? false : true);
}



inline boolean isGraph(int c)
{
  return ( isgraph (c) == 0 ? false : true);
}



inline boolean isLowerCase(int c)
{
  return (islower (c) == 0 ? false : true);
}



inline boolean isPrintable(int c)
{
  return ( isprint (c) == 0 ? false : true);
}




inline boolean isPunct(int c)
{
  return ( ispunct (c) == 0 ? false : true);
}





inline boolean isSpace(int c)
{
  return ( isspace (c) == 0 ? false : true);
}



inline boolean isUpperCase(int c)
{
  return ( isupper (c) == 0 ? false : true);
}




inline boolean isHexadecimalDigit(int c)
{
  return ( isxdigit (c) == 0 ? false : true);
}




inline int toAscii(int c)
{
  return toascii (c);
}








inline int toLowerCase(int c)
{
  return tolower (c);
}



inline int toUpperCase(int c)
{
  return toupper (c);
}
# 232 "C:\\Program Files (x86)\\Arduino\\hardware\\arduino\\avr\\cores\\arduino/Arduino.h" 2
# 1 "C:\\Program Files (x86)\\Arduino\\hardware\\arduino\\avr\\cores\\arduino/WString.h" 1

























# 1 "c:\\program files (x86)\\arduino\\hardware\\tools\\avr\\avr\\include\\stdlib.h" 1 3

# 1 "c:\\program files (x86)\\arduino\\hardware\\tools\\avr\\avr\\include\\stdlib.h" 3





































# 27 "C:\\Program Files (x86)\\Arduino\\hardware\\arduino\\avr\\cores\\arduino/WString.h" 2
# 1 "c:\\program files (x86)\\arduino\\hardware\\tools\\avr\\avr\\include\\string.h" 1 3






































# 28 "C:\\Program Files (x86)\\Arduino\\hardware\\arduino\\avr\\cores\\arduino/WString.h" 2
# 1 "c:\\program files (x86)\\arduino\\hardware\\tools\\avr\\avr\\include\\ctype.h" 1 3






































# 29 "C:\\Program Files (x86)\\Arduino\\hardware\\arduino\\avr\\cores\\arduino/WString.h" 2
# 1 "c:\\program files (x86)\\arduino\\hardware\\tools\\avr\\avr\\include\\avr\\pgmspace.h" 1 3
















































































# 30 "C:\\Program Files (x86)\\Arduino\\hardware\\arduino\\avr\\cores\\arduino/WString.h" 2


# 31 "C:\\Program Files (x86)\\Arduino\\hardware\\arduino\\avr\\cores\\arduino/WString.h"






class __FlashStringHelper;




class StringSumHelper;


class String
{
 
 
 
 typedef void (String::*StringIfHelperType)() const;
 void StringIfHelper() const {}

public:
 
 
 
 
 
 String(const char *cstr = "");
 String(const String &str);
 String(const __FlashStringHelper *str);

 String(String &&rval);
 String(StringSumHelper &&rval);

 explicit String(char c);
 explicit String(unsigned char, unsigned char base=10);
 explicit String(int, unsigned char base=10);
 explicit String(unsigned int, unsigned char base=10);
 explicit String(long, unsigned char base=10);
 explicit String(unsigned long, unsigned char base=10);
 explicit String(float, unsigned char decimalPlaces=2);
 explicit String(double, unsigned char decimalPlaces=2);
 ~String(void);

 
 
 
 
 unsigned char reserve(unsigned int size);
 inline unsigned int length(void) const {return len;}

 
 
 
 String & operator = (const String &rhs);
 String & operator = (const char *cstr);
 String & operator = (const __FlashStringHelper *str);

 String & operator = (String &&rval);
 String & operator = (StringSumHelper &&rval);


 

 
 
 
 unsigned char concat(const String &str);
 unsigned char concat(const char *cstr);
 unsigned char concat(char c);
 unsigned char concat(unsigned char c);
 unsigned char concat(int num);
 unsigned char concat(unsigned int num);
 unsigned char concat(long num);
 unsigned char concat(unsigned long num);
 unsigned char concat(float num);
 unsigned char concat(double num);
 unsigned char concat(const __FlashStringHelper * str);

 
 
 String & operator += (const String &rhs) {concat(rhs); return (*this);}
 String & operator += (const char *cstr) {concat(cstr); return (*this);}
 String & operator += (char c) {concat(c); return (*this);}
 String & operator += (unsigned char num) {concat(num); return (*this);}
 String & operator += (int num) {concat(num); return (*this);}
 String & operator += (unsigned int num) {concat(num); return (*this);}
 String & operator += (long num) {concat(num); return (*this);}
 String & operator += (unsigned long num) {concat(num); return (*this);}
 String & operator += (float num) {concat(num); return (*this);}
 String & operator += (double num) {concat(num); return (*this);}
 String & operator += (const __FlashStringHelper *str){concat(str); return (*this);}

 friend StringSumHelper & operator + (const StringSumHelper &lhs, const String &rhs);
 friend StringSumHelper & operator + (const StringSumHelper &lhs, const char *cstr);
 friend StringSumHelper & operator + (const StringSumHelper &lhs, char c);
 friend StringSumHelper & operator + (const StringSumHelper &lhs, unsigned char num);
 friend StringSumHelper & operator + (const StringSumHelper &lhs, int num);
 friend StringSumHelper & operator + (const StringSumHelper &lhs, unsigned int num);
 friend StringSumHelper & operator + (const StringSumHelper &lhs, long num);
 friend StringSumHelper & operator + (const StringSumHelper &lhs, unsigned long num);
 friend StringSumHelper & operator + (const StringSumHelper &lhs, float num);
 friend StringSumHelper & operator + (const StringSumHelper &lhs, double num);
 friend StringSumHelper & operator + (const StringSumHelper &lhs, const __FlashStringHelper *rhs);

 
 operator StringIfHelperType() const { return buffer ? &String::StringIfHelper : 0; }
 int compareTo(const String &s) const;
 unsigned char equals(const String &s) const;
 unsigned char equals(const char *cstr) const;
 unsigned char operator == (const String &rhs) const {return equals(rhs);}
 unsigned char operator == (const char *cstr) const {return equals(cstr);}
 unsigned char operator != (const String &rhs) const {return !equals(rhs);}
 unsigned char operator != (const char *cstr) const {return !equals(cstr);}
 unsigned char operator < (const String &rhs) const;
 unsigned char operator > (const String &rhs) const;
 unsigned char operator <= (const String &rhs) const;
 unsigned char operator >= (const String &rhs) const;
 unsigned char equalsIgnoreCase(const String &s) const;
 unsigned char startsWith( const String &prefix) const;
 unsigned char startsWith(const String &prefix, unsigned int offset) const;
 unsigned char endsWith(const String &suffix) const;

 
 char charAt(unsigned int index) const;
 void setCharAt(unsigned int index, char c);
 char operator [] (unsigned int index) const;
 char& operator [] (unsigned int index);
 void getBytes(unsigned char *buf, unsigned int bufsize, unsigned int index=0) const;
 void toCharArray(char *buf, unsigned int bufsize, unsigned int index=0) const
  { getBytes((unsigned char *)buf, bufsize, index); }
 const char* c_str() const { return buffer; }
 char* begin() { return buffer; }
 char* end() { return buffer + length(); }
 const char* begin() const { return c_str(); }
 const char* end() const { return c_str() + length(); }

 
 int indexOf( char ch ) const;
 int indexOf( char ch, unsigned int fromIndex ) const;
 int indexOf( const String &str ) const;
 int indexOf( const String &str, unsigned int fromIndex ) const;
 int lastIndexOf( char ch ) const;
 int lastIndexOf( char ch, unsigned int fromIndex ) const;
 int lastIndexOf( const String &str ) const;
 int lastIndexOf( const String &str, unsigned int fromIndex ) const;
 String substring( unsigned int beginIndex ) const { return substring(beginIndex, len); };
 String substring( unsigned int beginIndex, unsigned int endIndex ) const;

 
 void replace(char find, char replace);
 void replace(const String& find, const String& replace);
 void remove(unsigned int index);
 void remove(unsigned int index, unsigned int count);
 void toLowerCase(void);
 void toUpperCase(void);
 void trim(void);

 
 long toInt(void) const;
 float toFloat(void) const;
 double toDouble(void) const;

protected:
 char *buffer; 
 unsigned int capacity; 
 unsigned int len; 
protected:
 void init(void);
 void invalidate(void);
 unsigned char changeBuffer(unsigned int maxStrLen);
 unsigned char concat(const char *cstr, unsigned int length);

 
 String & copy(const char *cstr, unsigned int length);
 String & copy(const __FlashStringHelper *pstr, unsigned int length);

 void move(String &rhs);

};

class StringSumHelper : public String
{
public:
 StringSumHelper(const String &s) : String(s) {}
 StringSumHelper(const char *p) : String(p) {}
 StringSumHelper(char c) : String(c) {}
 StringSumHelper(unsigned char num) : String(num) {}
 StringSumHelper(int num) : String(num) {}
 StringSumHelper(unsigned int num) : String(num) {}
 StringSumHelper(long num) : String(num) {}
 StringSumHelper(unsigned long num) : String(num) {}
 StringSumHelper(float num) : String(num) {}
 StringSumHelper(double num) : String(num) {}
};
# 233 "C:\\Program Files (x86)\\Arduino\\hardware\\arduino\\avr\\cores\\arduino/Arduino.h" 2
# 1 "C:\\Program Files (x86)\\Arduino\\hardware\\arduino\\avr\\cores\\arduino/HardwareSerial.h" 1


























# 1 "c:\\program files (x86)\\arduino\\hardware\\tools\\avr\\avr\\include\\inttypes.h" 1 3

# 1 "c:\\program files (x86)\\arduino\\hardware\\tools\\avr\\avr\\include\\inttypes.h" 3
































# 28 "C:\\Program Files (x86)\\Arduino\\hardware\\arduino\\avr\\cores\\arduino/HardwareSerial.h" 2

# 1 "C:\\Program Files (x86)\\Arduino\\hardware\\arduino\\avr\\cores\\arduino/Stream.h" 1

# 1 "C:\\Program Files (x86)\\Arduino\\hardware\\arduino\\avr\\cores\\arduino/Stream.h"
























# 1 "c:\\program files (x86)\\arduino\\hardware\\tools\\avr\\avr\\include\\inttypes.h" 1 3

# 1 "c:\\program files (x86)\\arduino\\hardware\\tools\\avr\\avr\\include\\inttypes.h" 3
































# 26 "C:\\Program Files (x86)\\Arduino\\hardware\\arduino\\avr\\cores\\arduino/Stream.h" 2
# 1 "C:\\Program Files (x86)\\Arduino\\hardware\\arduino\\avr\\cores\\arduino/Print.h" 1

# 1 "C:\\Program Files (x86)\\Arduino\\hardware\\arduino\\avr\\cores\\arduino/Print.h"






















# 1 "c:\\program files (x86)\\arduino\\hardware\\tools\\avr\\avr\\include\\inttypes.h" 1 3

# 1 "c:\\program files (x86)\\arduino\\hardware\\tools\\avr\\avr\\include\\inttypes.h" 3
































# 24 "C:\\Program Files (x86)\\Arduino\\hardware\\arduino\\avr\\cores\\arduino/Print.h" 2
# 1 "c:\\program files (x86)\\arduino\\hardware\\tools\\avr\\avr\\include\\stdio.h" 1 3











































# 1 "c:\\program files (x86)\\arduino\\hardware\\tools\\avr\\avr\\include\\inttypes.h" 1 3
































# 45 "c:\\program files (x86)\\arduino\\hardware\\tools\\avr\\avr\\include\\stdio.h" 2 3
# 1 "c:\\program files (x86)\\arduino\\hardware\\tools\\avr\\lib\\gcc\\avr\\7.3.0\\include\\stdarg.h" 1 3 4


























# 36 "c:\\program files (x86)\\arduino\\hardware\\tools\\avr\\lib\\gcc\\avr\\7.3.0\\include\\stdarg.h" 3 4




typedef __builtin_va_list __gnuc_va_list;




# 56 "c:\\program files (x86)\\arduino\\hardware\\tools\\avr\\lib\\gcc\\avr\\7.3.0\\include\\stdarg.h" 3 4






# 86 "c:\\program files (x86)\\arduino\\hardware\\tools\\avr\\lib\\gcc\\avr\\7.3.0\\include\\stdarg.h" 3 4













typedef __gnuc_va_list va_list;
# 46 "c:\\program files (x86)\\arduino\\hardware\\tools\\avr\\avr\\include\\stdio.h" 2 3




# 1 "c:\\program files (x86)\\arduino\\hardware\\tools\\avr\\lib\\gcc\\avr\\7.3.0\\include\\stddef.h" 1 3 4



































# 46 "c:\\program files (x86)\\arduino\\hardware\\tools\\avr\\lib\\gcc\\avr\\7.3.0\\include\\stddef.h" 3 4

















# 92 "c:\\program files (x86)\\arduino\\hardware\\tools\\avr\\lib\\gcc\\avr\\7.3.0\\include\\stddef.h" 3 4












# 117 "c:\\program files (x86)\\arduino\\hardware\\tools\\avr\\lib\\gcc\\avr\\7.3.0\\include\\stddef.h" 3 4










# 165 "c:\\program files (x86)\\arduino\\hardware\\tools\\avr\\lib\\gcc\\avr\\7.3.0\\include\\stddef.h" 3 4




# 242 "c:\\program files (x86)\\arduino\\hardware\\tools\\avr\\lib\\gcc\\avr\\7.3.0\\include\\stddef.h" 3 4







# 362 "c:\\program files (x86)\\arduino\\hardware\\tools\\avr\\lib\\gcc\\avr\\7.3.0\\include\\stddef.h" 3 4




# 398 "c:\\program files (x86)\\arduino\\hardware\\tools\\avr\\lib\\gcc\\avr\\7.3.0\\include\\stddef.h" 3 4

# 51 "c:\\program files (x86)\\arduino\\hardware\\tools\\avr\\avr\\include\\stdio.h" 2 3

































































































































































































struct __file {
 char *buf; 
 unsigned char unget; 
 uint8_t flags; 
# 263 "c:\\program files (x86)\\arduino\\hardware\\tools\\avr\\avr\\include\\stdio.h" 3
 int size; 
 int len; 
 int (*put)(char, struct __file *); 
 int (*get)(struct __file *); 
 void *udata; 
};








typedef struct __file FILE;















































# 363 "c:\\program files (x86)\\arduino\\hardware\\tools\\avr\\avr\\include\\stdio.h" 3












# 399 "c:\\program files (x86)\\arduino\\hardware\\tools\\avr\\avr\\include\\stdio.h" 3
extern "C" {







extern struct __file *__iob[];
# 418 "c:\\program files (x86)\\arduino\\hardware\\tools\\avr\\avr\\include\\stdio.h" 3

extern FILE *fdevopen(int (*__put)(char, FILE*), int (*__get)(FILE*));
















extern int fclose(FILE *__stream);













































































































































































extern int vfprintf(FILE *__stream, const char *__fmt, va_list __ap);





extern int vfprintf_P(FILE *__stream, const char *__fmt, va_list __ap);






extern int fputc(int __c, FILE *__stream);




extern int putc(int __c, FILE *__stream);


extern int putchar(int __c);



















extern int printf(const char *__fmt, ...);





extern int printf_P(const char *__fmt, ...);







extern int vprintf(const char *__fmt, va_list __ap);





extern int sprintf(char *__s, const char *__fmt, ...);





extern int sprintf_P(char *__s, const char *__fmt, ...);









extern int snprintf(char *__s, size_t __n, const char *__fmt, ...);





extern int snprintf_P(char *__s, size_t __n, const char *__fmt, ...);





extern int vsprintf(char *__s, const char *__fmt, va_list ap);





extern int vsprintf_P(char *__s, const char *__fmt, va_list ap);









extern int vsnprintf(char *__s, size_t __n, const char *__fmt, va_list ap);





extern int vsnprintf_P(char *__s, size_t __n, const char *__fmt, va_list ap);




extern int fprintf(FILE *__stream, const char *__fmt, ...);





extern int fprintf_P(FILE *__stream, const char *__fmt, ...);






extern int fputs(const char *__str, FILE *__stream);




extern int fputs_P(const char *__str, FILE *__stream);





extern int puts(const char *__str);




extern int puts_P(const char *__str);








extern size_t fwrite(const void *__ptr, size_t __size, size_t __nmemb,
         FILE *__stream);







extern int fgetc(FILE *__stream);




extern int getc(FILE *__stream);


extern int getchar(void);






























extern int ungetc(int __c, FILE *__stream);











extern char *fgets(char *__str, int __size, FILE *__stream);






extern char *gets(char *__str);










extern size_t fread(void *__ptr, size_t __size, size_t __nmemb,
        FILE *__stream);




extern void clearerr(FILE *__stream);










extern int feof(FILE *__stream);










extern int ferror(FILE *__stream);






extern int vfscanf(FILE *__stream, const char *__fmt, va_list __ap);




extern int vfscanf_P(FILE *__stream, const char *__fmt, va_list __ap);







extern int fscanf(FILE *__stream, const char *__fmt, ...);




extern int fscanf_P(FILE *__stream, const char *__fmt, ...);






extern int scanf(const char *__fmt, ...);




extern int scanf_P(const char *__fmt, ...);







extern int vscanf(const char *__fmt, va_list __ap);







extern int sscanf(const char *__buf, const char *__fmt, ...);




extern int sscanf_P(const char *__buf, const char *__fmt, ...);
# 940 "c:\\program files (x86)\\arduino\\hardware\\tools\\avr\\avr\\include\\stdio.h" 3
static __inline__ int fflush(FILE *stream __attribute__((unused)))
{
 return 0;
}






__extension__ typedef long long fpos_t;
extern int fgetpos(FILE *stream, fpos_t *pos);
extern FILE *fopen(const char *path, const char *mode);
extern FILE *freopen(const char *path, const char *mode, FILE *stream);
extern FILE *fdopen(int, const char *);
extern int fseek(FILE *stream, long offset, int whence);
extern int fsetpos(FILE *stream, fpos_t *pos);
extern long ftell(FILE *stream);
extern int fileno(FILE *);
extern void perror(const char *s);
extern int remove(const char *pathname);
extern int rename(const char *oldpath, const char *newpath);
extern void rewind(FILE *stream);
extern void setbuf(FILE *stream, char *buf);
extern int setvbuf(FILE *stream, char *buf, int mode, size_t size);
extern FILE *tmpfile(void);
extern char *tmpnam (char *s);



}










# 25 "C:\\Program Files (x86)\\Arduino\\hardware\\arduino\\avr\\cores\\arduino/Print.h" 2

# 1 "C:\\Program Files (x86)\\Arduino\\hardware\\arduino\\avr\\cores\\arduino/WString.h" 1

# 1 "C:\\Program Files (x86)\\Arduino\\hardware\\arduino\\avr\\cores\\arduino/WString.h"




















# 27 "C:\\Program Files (x86)\\Arduino\\hardware\\arduino\\avr\\cores\\arduino/Print.h" 2
# 1 "C:\\Program Files (x86)\\Arduino\\hardware\\arduino\\avr\\cores\\arduino/Printable.h" 1






















# 1 "c:\\program files (x86)\\arduino\\hardware\\tools\\avr\\avr\\include\\stdlib.h" 1 3

# 1 "c:\\program files (x86)\\arduino\\hardware\\tools\\avr\\avr\\include\\stdlib.h" 3





































# 24 "C:\\Program Files (x86)\\Arduino\\hardware\\arduino\\avr\\cores\\arduino/Printable.h" 2


# 25 "C:\\Program Files (x86)\\Arduino\\hardware\\arduino\\avr\\cores\\arduino/Printable.h"
class Print;







class Printable
{
  public:
    virtual size_t printTo(Print& p) const = 0;
};
# 28 "C:\\Program Files (x86)\\Arduino\\hardware\\arduino\\avr\\cores\\arduino/Print.h" 2
# 37 "C:\\Program Files (x86)\\Arduino\\hardware\\arduino\\avr\\cores\\arduino/Print.h"
class Print
{
  private:
    int write_error;
    size_t printNumber(unsigned long, uint8_t);
    size_t printFloat(double, uint8_t);
  protected:
    void setWriteError(int err = 1) { write_error = err; }
  public:
    Print() : write_error(0) {}

    int getWriteError() { return write_error; }
    void clearWriteError() { setWriteError(0); }

    virtual size_t write(uint8_t) = 0;
    size_t write(const char *str) {
      if (str == 
# 53 "C:\\Program Files (x86)\\Arduino\\hardware\\arduino\\avr\\cores\\arduino/Print.h" 3 4
                __null
# 53 "C:\\Program Files (x86)\\Arduino\\hardware\\arduino\\avr\\cores\\arduino/Print.h"
                    ) return 0;
      return write((const uint8_t *)str, strlen(str));
    }
    virtual size_t write(const uint8_t *buffer, size_t size);
    size_t write(const char *buffer, size_t size) {
      return write((const uint8_t *)buffer, size);
    }

    
    
    virtual int availableForWrite() { return 0; }

    size_t print(const __FlashStringHelper *);
    size_t print(const String &);
    size_t print(const char[]);
    size_t print(char);
    size_t print(unsigned char, int = 10);
    size_t print(int, int = 10);
    size_t print(unsigned int, int = 10);
    size_t print(long, int = 10);
    size_t print(unsigned long, int = 10);
    size_t print(double, int = 2);
    size_t print(const Printable&);

    size_t println(const __FlashStringHelper *);
    size_t println(const String &s);
    size_t println(const char[]);
    size_t println(char);
    size_t println(unsigned char, int = 10);
    size_t println(int, int = 10);
    size_t println(unsigned int, int = 10);
    size_t println(long, int = 10);
    size_t println(unsigned long, int = 10);
    size_t println(double, int = 2);
    size_t println(const Printable&);
    size_t println(void);

    virtual void flush() {  }
};
# 27 "C:\\Program Files (x86)\\Arduino\\hardware\\arduino\\avr\\cores\\arduino/Stream.h" 2














enum LookaheadMode{
    SKIP_ALL, 
    SKIP_NONE, 
    SKIP_WHITESPACE 
};



class Stream : public Print
{
  protected:
    unsigned long _timeout; 
    unsigned long _startMillis; 
    int timedRead(); 
    int timedPeek(); 
    int peekNextDigit(LookaheadMode lookahead, bool detectDecimal); 

  public:
    virtual int available() = 0;
    virtual int read() = 0;
    virtual int peek() = 0;

    Stream() {_timeout=1000;}



  void setTimeout(unsigned long timeout); 
  unsigned long getTimeout(void) { return _timeout; }

  bool find(char *target); 
  bool find(uint8_t *target) { return find ((char *)target); }
  

  bool find(char *target, size_t length); 
  bool find(uint8_t *target, size_t length) { return find ((char *)target, length); }
  

  bool find(char target) { return find (&target, 1); }

  bool findUntil(char *target, char *terminator); 
  bool findUntil(uint8_t *target, char *terminator) { return findUntil((char *)target, terminator); }

  bool findUntil(char *target, size_t targetLen, char *terminate, size_t termLen); 
  bool findUntil(uint8_t *target, size_t targetLen, char *terminate, size_t termLen) {return findUntil((char *)target, targetLen, terminate, termLen); }

  long parseInt(LookaheadMode lookahead = SKIP_ALL, char ignore = '\x01' );
  
  
  
  
  

  float parseFloat(LookaheadMode lookahead = SKIP_ALL, char ignore = '\x01' );
  

  size_t readBytes( char *buffer, size_t length); 
  size_t readBytes( uint8_t *buffer, size_t length) { return readBytes((char *)buffer, length); }
  
  

  size_t readBytesUntil( char terminator, char *buffer, size_t length); 
  size_t readBytesUntil( char terminator, uint8_t *buffer, size_t length) { return readBytesUntil(terminator, (char *)buffer, length); }
  
  

  
  String readString();
  String readStringUntil(char terminator);

  protected:
  long parseInt(char ignore) { return parseInt(SKIP_ALL, ignore); }
  float parseFloat(char ignore) { return parseFloat(SKIP_ALL, ignore); }
  
  
  

  struct MultiTarget {
    const char *str; 
    size_t len; 
    size_t index; 
  };

  
  
  int findMulti(struct MultiTarget *targets, int tCount);
};
# 30 "C:\\Program Files (x86)\\Arduino\\hardware\\arduino\\avr\\cores\\arduino/HardwareSerial.h" 2












# 59 "C:\\Program Files (x86)\\Arduino\\hardware\\arduino\\avr\\cores\\arduino/HardwareSerial.h"
typedef uint8_t tx_buffer_index_t;




typedef uint8_t rx_buffer_index_t;



# 93 "C:\\Program Files (x86)\\Arduino\\hardware\\arduino\\avr\\cores\\arduino/HardwareSerial.h"
class HardwareSerial : public Stream
{
  protected:
    volatile uint8_t * const _ubrrh;
    volatile uint8_t * const _ubrrl;
    volatile uint8_t * const _ucsra;
    volatile uint8_t * const _ucsrb;
    volatile uint8_t * const _ucsrc;
    volatile uint8_t * const _udr;
    
    bool _written;

    volatile rx_buffer_index_t _rx_buffer_head;
    volatile rx_buffer_index_t _rx_buffer_tail;
    volatile tx_buffer_index_t _tx_buffer_head;
    volatile tx_buffer_index_t _tx_buffer_tail;

    
    
    
    unsigned char _rx_buffer[64];
    unsigned char _tx_buffer[64];

  public:
    inline HardwareSerial(
      volatile uint8_t *ubrrh, volatile uint8_t *ubrrl,
      volatile uint8_t *ucsra, volatile uint8_t *ucsrb,
      volatile uint8_t *ucsrc, volatile uint8_t *udr);
    void begin(unsigned long baud) { begin(baud, 0x06); }
    void begin(unsigned long, uint8_t);
    void end();
    virtual int available(void);
    virtual int peek(void);
    virtual int read(void);
    virtual int availableForWrite(void);
    virtual void flush(void);
    virtual size_t write(uint8_t);
    inline size_t write(unsigned long n) { return write((uint8_t)n); }
    inline size_t write(long n) { return write((uint8_t)n); }
    inline size_t write(unsigned int n) { return write((uint8_t)n); }
    inline size_t write(int n) { return write((uint8_t)n); }
    using Print::write; 
    operator bool() { return true; }

    
    inline void _rx_complete_irq(void);
    void _tx_udr_empty_irq(void);
};


  extern HardwareSerial Serial;
# 159 "C:\\Program Files (x86)\\Arduino\\hardware\\arduino\\avr\\cores\\arduino/HardwareSerial.h"
extern void serialEventRun(void) __attribute__((weak));
# 234 "C:\\Program Files (x86)\\Arduino\\hardware\\arduino\\avr\\cores\\arduino/Arduino.h" 2
# 1 "C:\\Program Files (x86)\\Arduino\\hardware\\arduino\\avr\\cores\\arduino/USBAPI.h" 1






















# 1 "c:\\program files (x86)\\arduino\\hardware\\tools\\avr\\avr\\include\\inttypes.h" 1 3

# 1 "c:\\program files (x86)\\arduino\\hardware\\tools\\avr\\avr\\include\\inttypes.h" 3
































# 24 "C:\\Program Files (x86)\\Arduino\\hardware\\arduino\\avr\\cores\\arduino/USBAPI.h" 2
# 1 "c:\\program files (x86)\\arduino\\hardware\\tools\\avr\\avr\\include\\avr\\pgmspace.h" 1 3
















































































# 25 "C:\\Program Files (x86)\\Arduino\\hardware\\arduino\\avr\\cores\\arduino/USBAPI.h" 2
# 1 "c:\\program files (x86)\\arduino\\hardware\\tools\\avr\\avr\\include\\avr\\eeprom.h" 1 3





































# 1 "c:\\program files (x86)\\arduino\\hardware\\tools\\avr\\avr\\include\\avr\\io.h" 1 3






























































































# 39 "c:\\program files (x86)\\arduino\\hardware\\tools\\avr\\avr\\include\\avr\\eeprom.h" 2 3
# 50 "c:\\program files (x86)\\arduino\\hardware\\tools\\avr\\avr\\include\\avr\\eeprom.h" 3
# 1 "c:\\program files (x86)\\arduino\\hardware\\tools\\avr\\lib\\gcc\\avr\\7.3.0\\include\\stddef.h" 1 3 4






























































# 92 "c:\\program files (x86)\\arduino\\hardware\\tools\\avr\\lib\\gcc\\avr\\7.3.0\\include\\stddef.h" 3 4












# 117 "c:\\program files (x86)\\arduino\\hardware\\tools\\avr\\lib\\gcc\\avr\\7.3.0\\include\\stddef.h" 3 4










# 149 "c:\\program files (x86)\\arduino\\hardware\\tools\\avr\\lib\\gcc\\avr\\7.3.0\\include\\stddef.h" 3 4
typedef int ptrdiff_t;
# 160 "c:\\program files (x86)\\arduino\\hardware\\tools\\avr\\lib\\gcc\\avr\\7.3.0\\include\\stddef.h" 3 4









# 242 "c:\\program files (x86)\\arduino\\hardware\\tools\\avr\\lib\\gcc\\avr\\7.3.0\\include\\stddef.h" 3 4







# 362 "c:\\program files (x86)\\arduino\\hardware\\tools\\avr\\lib\\gcc\\avr\\7.3.0\\include\\stddef.h" 3 4




# 398 "c:\\program files (x86)\\arduino\\hardware\\tools\\avr\\lib\\gcc\\avr\\7.3.0\\include\\stddef.h" 3 4

# 416 "c:\\program files (x86)\\arduino\\hardware\\tools\\avr\\lib\\gcc\\avr\\7.3.0\\include\\stddef.h" 3 4










typedef struct {
  long long __max_align_ll __attribute__((__aligned__(__alignof__(long long))));
  long double __max_align_ld __attribute__((__aligned__(__alignof__(long double))));
  







} max_align_t;






  typedef decltype(nullptr) nullptr_t;
# 51 "c:\\program files (x86)\\arduino\\hardware\\tools\\avr\\avr\\include\\avr\\eeprom.h" 2 3









































extern "C" {
# 103 "c:\\program files (x86)\\arduino\\hardware\\tools\\avr\\avr\\include\\avr\\eeprom.h" 3










# 128 "c:\\program files (x86)\\arduino\\hardware\\tools\\avr\\avr\\include\\avr\\eeprom.h" 3











uint8_t eeprom_read_byte (const uint8_t *__p) __attribute__((__pure__));




uint16_t eeprom_read_word (const uint16_t *__p) __attribute__((__pure__));




uint32_t eeprom_read_dword (const uint32_t *__p) __attribute__((__pure__));




float eeprom_read_float (const float *__p) __attribute__((__pure__));





void eeprom_read_block (void *__dst, const void *__src, size_t __n);





void eeprom_write_byte (uint8_t *__p, uint8_t __value);




void eeprom_write_word (uint16_t *__p, uint16_t __value);




void eeprom_write_dword (uint32_t *__p, uint32_t __value);




void eeprom_write_float (float *__p, float __value);





void eeprom_write_block (const void *__src, void *__dst, size_t __n);





void eeprom_update_byte (uint8_t *__p, uint8_t __value);




void eeprom_update_word (uint16_t *__p, uint16_t __value);




void eeprom_update_dword (uint32_t *__p, uint32_t __value);




void eeprom_update_float (float *__p, float __value);





void eeprom_update_block (const void *__src, void *__dst, size_t __n);




























}
# 26 "C:\\Program Files (x86)\\Arduino\\hardware\\arduino\\avr\\cores\\arduino/USBAPI.h" 2
# 1 "c:\\program files (x86)\\arduino\\hardware\\tools\\avr\\avr\\include\\avr\\interrupt.h" 1 3

































# 27 "C:\\Program Files (x86)\\Arduino\\hardware\\arduino\\avr\\cores\\arduino/USBAPI.h" 2
# 1 "c:\\program files (x86)\\arduino\\hardware\\tools\\avr\\avr\\include\\util\\delay.h" 1 3

































# 44 "c:\\program files (x86)\\arduino\\hardware\\tools\\avr\\avr\\include\\util\\delay.h" 3
# 1 "c:\\program files (x86)\\arduino\\hardware\\tools\\avr\\avr\\include\\inttypes.h" 1 3
































# 45 "c:\\program files (x86)\\arduino\\hardware\\tools\\avr\\avr\\include\\util\\delay.h" 2 3
# 1 "c:\\program files (x86)\\arduino\\hardware\\tools\\avr\\avr\\include\\util\\delay_basic.h" 1 3




































# 1 "c:\\program files (x86)\\arduino\\hardware\\tools\\avr\\avr\\include\\inttypes.h" 1 3
































# 38 "c:\\program files (x86)\\arduino\\hardware\\tools\\avr\\avr\\include\\util\\delay_basic.h" 2 3


static __inline__ void _delay_loop_1(uint8_t __count) __attribute__((__always_inline__));
static __inline__ void _delay_loop_2(uint16_t __count) __attribute__((__always_inline__));






































void
_delay_loop_1(uint8_t __count)
{
 __asm__ volatile (
  "1: dec %0" "\n\t"
  "brne 1b"
  : "=r" (__count)
  : "0" (__count)
 );
}












void
_delay_loop_2(uint16_t __count)
{
 __asm__ volatile (
  "1: sbiw %0,1" "\n\t"
  "brne 1b"
  : "=w" (__count)
  : "0" (__count)
 );
}
# 46 "c:\\program files (x86)\\arduino\\hardware\\tools\\avr\\avr\\include\\util\\delay.h" 2 3
# 1 "c:\\program files (x86)\\arduino\\hardware\\tools\\avr\\avr\\include\\math.h" 1 3














































# 47 "c:\\program files (x86)\\arduino\\hardware\\tools\\avr\\avr\\include\\util\\delay.h" 2 3







































static __inline__ void _delay_us(double __us) __attribute__((__always_inline__));
static __inline__ void _delay_ms(double __ms) __attribute__((__always_inline__));
# 118 "c:\\program files (x86)\\arduino\\hardware\\tools\\avr\\avr\\include\\util\\delay.h" 3
# 1 "c:\\program files (x86)\\arduino\\hardware\\tools\\avr\\avr\\include\\math.h" 1 3














































# 119 "c:\\program files (x86)\\arduino\\hardware\\tools\\avr\\avr\\include\\util\\delay.h" 2 3














































void
_delay_ms(double __ms)
{
 double __tmp ;



 uint32_t __ticks_dc;
 extern void __builtin_avr_delay_cycles(unsigned long);
 __tmp = ((
# 174 "c:\\program files (x86)\\arduino\\hardware\\tools\\avr\\avr\\include\\util\\delay.h"
          16000000L
# 174 "c:\\program files (x86)\\arduino\\hardware\\tools\\avr\\avr\\include\\util\\delay.h" 3
               ) / 1e3) * __ms;
# 183 "c:\\program files (x86)\\arduino\\hardware\\tools\\avr\\avr\\include\\util\\delay.h" 3
  
  __ticks_dc = (uint32_t)(ceil(fabs(__tmp)));


 __builtin_avr_delay_cycles(__ticks_dc);
# 210 "c:\\program files (x86)\\arduino\\hardware\\tools\\avr\\avr\\include\\util\\delay.h" 3
}











































void
_delay_us(double __us)
{
 double __tmp ;



 uint32_t __ticks_dc;
 extern void __builtin_avr_delay_cycles(unsigned long);
 __tmp = ((
# 263 "c:\\program files (x86)\\arduino\\hardware\\tools\\avr\\avr\\include\\util\\delay.h"
          16000000L
# 263 "c:\\program files (x86)\\arduino\\hardware\\tools\\avr\\avr\\include\\util\\delay.h" 3
               ) / 1e6) * __us;
# 272 "c:\\program files (x86)\\arduino\\hardware\\tools\\avr\\avr\\include\\util\\delay.h" 3
  
  __ticks_dc = (uint32_t)(ceil(fabs(__tmp)));


 __builtin_avr_delay_cycles(__ticks_dc);
# 299 "c:\\program files (x86)\\arduino\\hardware\\tools\\avr\\avr\\include\\util\\delay.h" 3
}
# 28 "C:\\Program Files (x86)\\Arduino\\hardware\\arduino\\avr\\cores\\arduino/USBAPI.h" 2


# 29 "C:\\Program Files (x86)\\Arduino\\hardware\\arduino\\avr\\cores\\arduino/USBAPI.h"
typedef unsigned char u8;
typedef unsigned short u16;
typedef unsigned long u32;

# 1 "C:\\Program Files (x86)\\Arduino\\hardware\\arduino\\avr\\cores\\arduino/Arduino.h" 1


















# 34 "C:\\Program Files (x86)\\Arduino\\hardware\\arduino\\avr\\cores\\arduino/USBAPI.h" 2



# 235 "C:\\Program Files (x86)\\Arduino\\hardware\\arduino\\avr\\cores\\arduino/Arduino.h" 2




uint16_t makeWord(uint16_t w);
uint16_t makeWord(byte h, byte l);



unsigned long pulseIn(uint8_t pin, uint8_t state, unsigned long timeout = 1000000L);
unsigned long pulseInLong(uint8_t pin, uint8_t state, unsigned long timeout = 1000000L);

void tone(uint8_t _pin, unsigned int frequency, unsigned long duration = 0);
void noTone(uint8_t _pin);


long random(long);
long random(long, long);
void randomSeed(unsigned long);
long map(long, long, long, long, long);



# 1 "C:\\Program Files (x86)\\Arduino\\hardware\\arduino\\avr\\variants\\standard/pins_arduino.h" 1

























# 1 "c:\\program files (x86)\\arduino\\hardware\\tools\\avr\\avr\\include\\avr\\pgmspace.h" 1 3

# 1 "c:\\program files (x86)\\arduino\\hardware\\tools\\avr\\avr\\include\\avr\\pgmspace.h" 3
















































































# 27 "C:\\Program Files (x86)\\Arduino\\hardware\\arduino\\avr\\variants\\standard/pins_arduino.h" 2
# 43 "C:\\Program Files (x86)\\Arduino\\hardware\\arduino\\avr\\variants\\standard/pins_arduino.h"

# 43 "C:\\Program Files (x86)\\Arduino\\hardware\\arduino\\avr\\variants\\standard/pins_arduino.h"
static const uint8_t SS = (10);
static const uint8_t MOSI = (11);
static const uint8_t MISO = (12);
static const uint8_t SCK = (13);




static const uint8_t SDA = (18);
static const uint8_t SCL = (19);
# 65 "C:\\Program Files (x86)\\Arduino\\hardware\\arduino\\avr\\variants\\standard/pins_arduino.h"
static const uint8_t A0 = (14);
static const uint8_t A1 = (15);
static const uint8_t A2 = (16);
static const uint8_t A3 = (17);
static const uint8_t A4 = (18);
static const uint8_t A5 = (19);
static const uint8_t A6 = (20);
static const uint8_t A7 = (21);
# 236 "C:\\Program Files (x86)\\Arduino\\hardware\\arduino\\avr\\variants\\standard/pins_arduino.h"















# 259 "C:\\Program Files (x86)\\Arduino\\hardware\\arduino\\avr\\cores\\arduino/Arduino.h" 2
# 7 "C:\\Users\\stein\\Downloads\\Yamaha3DPrint\\yamaha3Dprint\\ArduinoSensorIO\\ArduinoSensorIO\\ArduinoSensorIO.h" 2
# 1 "C:\\Users\\stein\\Downloads\\Yamaha3DPrint\\yamaha3Dprint\\ArduinoSensorIO\\Libraries\\AccelStepper\\1.61\\AccelStepper\\src/MultiStepper.h" 1





# 1 "c:\\program files (x86)\\arduino\\hardware\\tools\\avr\\avr\\include\\stdlib.h" 1 3

# 1 "c:\\program files (x86)\\arduino\\hardware\\tools\\avr\\avr\\include\\stdlib.h" 3





































# 7 "C:\\Users\\stein\\Downloads\\Yamaha3DPrint\\yamaha3Dprint\\ArduinoSensorIO\\Libraries\\AccelStepper\\1.61\\AccelStepper\\src/MultiStepper.h" 2

# 1 "C:\\Program Files (x86)\\Arduino\\hardware\\arduino\\avr\\cores\\arduino/Arduino.h" 1

# 1 "C:\\Program Files (x86)\\Arduino\\hardware\\arduino\\avr\\cores\\arduino/Arduino.h"


















# 9 "C:\\Users\\stein\\Downloads\\Yamaha3DPrint\\yamaha3Dprint\\ArduinoSensorIO\\Libraries\\AccelStepper\\1.61\\AccelStepper\\src/MultiStepper.h" 2







class AccelStepper;
















class MultiStepper
{
public:
    
    MultiStepper();

    
    
    
    
    boolean addStepper(AccelStepper& stepper);

    
    
    
    
    
    
    
    void moveTo(long absolute[]);

    
    
    
    boolean run();

    
    
    
    void runSpeedToPosition();

private:
    
    
    AccelStepper* _steppers[10];

    
    
    uint8_t _num_steppers;
};




# 8 "C:\\Users\\stein\\Downloads\\Yamaha3DPrint\\yamaha3Dprint\\ArduinoSensorIO\\ArduinoSensorIO\\ArduinoSensorIO.h" 2
# 1 "C:\\Users\\stein\\Downloads\\Yamaha3DPrint\\yamaha3Dprint\\ArduinoSensorIO\\Libraries\\AccelStepper\\1.61\\AccelStepper\\src/AccelStepper.h" 1



































































































































































































































































# 1 "c:\\program files (x86)\\arduino\\hardware\\tools\\avr\\avr\\include\\stdlib.h" 1 3

# 1 "c:\\program files (x86)\\arduino\\hardware\\tools\\avr\\avr\\include\\stdlib.h" 3





































# 261 "C:\\Users\\stein\\Downloads\\Yamaha3DPrint\\yamaha3Dprint\\ArduinoSensorIO\\Libraries\\AccelStepper\\1.61\\AccelStepper\\src/AccelStepper.h" 2

# 1 "C:\\Program Files (x86)\\Arduino\\hardware\\arduino\\avr\\cores\\arduino/Arduino.h" 1

# 1 "C:\\Program Files (x86)\\Arduino\\hardware\\arduino\\avr\\cores\\arduino/Arduino.h"


















# 263 "C:\\Users\\stein\\Downloads\\Yamaha3DPrint\\yamaha3Dprint\\ArduinoSensorIO\\Libraries\\AccelStepper\\1.61\\AccelStepper\\src/AccelStepper.h" 2





























































class AccelStepper
{
public:
    
    
    
    
    typedef enum
    {
 FUNCTION = 0, 
 DRIVER = 1, 
 FULL2WIRE = 2, 
 FULL3WIRE = 3, 
        FULL4WIRE = 4, 
 HALF3WIRE = 6, 
 HALF4WIRE = 8 
    } MotorInterfaceType;

    
    
    
    
    
    
    
    
    
    
    
    
    
    
    
    
    
    
    
    
    
    
    
    
    
    
    
    
    
    
    
    AccelStepper(uint8_t interface = AccelStepper::FULL4WIRE, uint8_t pin1 = 2, uint8_t pin2 = 3, uint8_t pin3 = 4, uint8_t pin4 = 5, bool enable = true);

    
    
    
    
    
    
    
    
    AccelStepper(void (*forward)(), void (*backward)());

    
    
    
    
    
    
    void moveTo(long absolute);

    
    
    
    void move(long relative);

    
    
    
    
    
    
    boolean run();

    
    
    
    
    boolean runSpeed();

    
    
    
    
    
    
    
    void setMaxSpeed(float speed);

    
    
    
    float maxSpeed();

    
    
    
    
    void setAcceleration(float acceleration);

    
    
    
    
    
    
    
    void setSpeed(float speed);

    
    
    float speed();

    
    
    
    long distanceToGo();

    
    
    
    long targetPosition();

    
    
    
    long currentPosition();

    
    
    
    
    
    
    
    void setCurrentPosition(long position);

    
    
    
    void runToPosition();

    
    
    
    boolean runSpeedToPosition();

    
    
    
    
    void runToNewPosition(long position);

    
    
    void stop();

    
    
    
    
    
    
    
    virtual void disableOutputs();

    
    
    
    virtual void enableOutputs();

    
    
    
    
    void setMinPulseWidth(unsigned int minWidth);

    
    
    
    
    
    
    
    void setEnablePin(uint8_t enablePin = 0xff);

    
    
    
    
    void setPinsInverted(bool directionInvert = false, bool stepInvert = false, bool enableInvert = false);

    
    
    
    
    
    
    void setPinsInverted(bool pin1Invert, bool pin2Invert, bool pin3Invert, bool pin4Invert, bool enableInvert);

    
    
    bool isRunning();

protected:

    
    
    typedef enum
    {
 DIRECTION_CCW = 0, 
        DIRECTION_CW = 1 
    } Direction;

    
    
    
    
    
    
    
    
    void computeNewSpeed();

    
    
    
    
    
    virtual void setOutputPins(uint8_t mask);

    
    
    
    
    
    virtual void step(long step);

    
    
    
    virtual void step0(long step);

    
    
    
    
    
    
    virtual void step1(long step);

    
    
    
    
    virtual void step2(long step);

    
    
    
    
    
    virtual void step3(long step);

    
    
    
    
    
    virtual void step4(long step);

    
    
    
    
    
    virtual void step6(long step);

    
    
    
    
    
    virtual void step8(long step);

    
    
    boolean _direction; 

private:
    
    
    uint8_t _interface; 

    
    
    uint8_t _pin[4];

    
    uint8_t _pinInverted[4];

    
    long _currentPos; 

    
    
    
    long _targetPos; 

    
    
    float _speed; 

    
    float _maxSpeed;

    
    
    float _acceleration;
    float _sqrt_twoa; 

    
    
    unsigned long _stepInterval;

    
    unsigned long _lastStepTime;

    
    unsigned int _minPulseWidth;

    
    

    
    

    
    bool _enableInverted;

    
    uint8_t _enablePin;

    
    void (*_forward)();

    
    void (*_backward)();

    
    long _n;

    
    float _c0;

    
    float _cn;

    
    float _cmin; 

};






















































# 9 "C:\\Users\\stein\\Downloads\\Yamaha3DPrint\\yamaha3Dprint\\ArduinoSensorIO\\ArduinoSensorIO\\ArduinoSensorIO.h" 2
# 1 "c:\\program files (x86)\\arduino\\hardware\\tools\\avr\\avr\\include\\string.h" 1 3

# 1 "c:\\program files (x86)\\arduino\\hardware\\tools\\avr\\avr\\include\\string.h" 3






































# 10 "C:\\Users\\stein\\Downloads\\Yamaha3DPrint\\yamaha3Dprint\\ArduinoSensorIO\\ArduinoSensorIO\\ArduinoSensorIO.h" 2
 
# 10 "C:\\Users\\stein\\Downloads\\Yamaha3DPrint\\yamaha3Dprint\\ArduinoSensorIO\\ArduinoSensorIO\\ArduinoSensorIO.h"
class ArduinoIO
 {
 private:
  int pulsePin;
  int dirPin;
  int enblPin;
  int ExtruderHeizPin;
  int ExtruderTempPin;
  int ExtruderTempVoltagePin;
  int SetExtruderFanPin;
  const int ThermistorTable[32][2]{ { 1, 713 }, { 17,300 }, { 20, 290 }, { 23,280 }, { 27,270 }, { 31,260 }, { 37, 250 }, { 43,240 }, { 51,230 },{61,220},{73,210},{87,200},{106,190},{128,180},{155,170},{189, 160},{230,150},{278,140},{336,130},{402,120},{476,110},{554,100},{635,90},{713,80},{784,70},{846,60},{897,50},{937,40},{966,30},{986,20},{1000,10},{1010,0} };

  float aktuelleExtruderTemperatur;
  float zielExtruderTemperatur;
  bool newPostion;
  bool setDruckbett;
  bool setExtruderheizen;
  AccelStepper mystepper;

 public:
  ArduinoIO();
  void SetSpeed(float);
  void SetMoveE(float);
  void SetOk();
  float GetExtruderTemperatur();
  void SetExtruderTemperatur(float);
  void ExtruderTemperaturRegelung();
  void Initialisieren();
  void Run();
  void UpdateSerial();
  void NewCommand(String, String);
  void Checkfinish(bool);
 };

};
# 2 "C:\\Users\\stein\\Downloads\\Yamaha3DPrint\\yamaha3Dprint\\ArduinoSensorIO\\ArduinoSensorIO\\ArduinoSensorIO.cpp" 2


ArduinoIO::ArduinoIO()
{
 this->pulsePin = 1; 
 this->dirPin = 2; 
 this->enblPin = 3; 
 this->ExtruderHeizPin = 5;
 this->ExtruderTempVoltagePin = 4;
 this->ExtruderTempPin = 0;
 this->aktuelleExtruderTemperatur = 0;
 this->zielExtruderTemperatur = 30;
 this->newPostion = false;
 this->setDruckbett = false;
 this->setExtruderheizen = false;
 mystepper = AccelStepper(1, pulsePin, dirPin);
 mystepper.setAcceleration(1000);
}

void ArduinoIO::SetSpeed(float speed)
{
 mystepper.setMaxSpeed(speed);
 delay(20);
 SetOk();
}

void ArduinoIO::SetMoveE(float amount)
{
 int Steps = amount * 409;
 mystepper.move(Steps);
 newPostion = true;
}

void ArduinoIO::SetOk()
{
 Serial.println("OK");
}
void ArduinoIO::Checkfinish(bool move)
{
 if (move == false && newPostion == true)
 {
  SetOk();
  newPostion = false;
 }
}

void ArduinoIO::ExtruderTemperaturRegelung()
{
 this->aktuelleExtruderTemperatur = GetExtruderTemperatur();
 if (zielExtruderTemperatur >= aktuelleExtruderTemperatur + 1)
 {
  digitalWrite(ExtruderHeizPin, 0x1);
 }
 if (zielExtruderTemperatur <= aktuelleExtruderTemperatur - 1)
 {
  digitalWrite(ExtruderHeizPin, 0x0);
 }
}

void ArduinoIO::Initialisieren()
{
 pinMode(pulsePin, 0x1);
 pinMode(dirPin, 0x1);
 pinMode(enblPin, 0x1);
 pinMode(ExtruderHeizPin, 0x1);
 pinMode(ExtruderTempVoltagePin, 0x1);
 pinMode(ExtruderTempPin, 0x0);
 pinMode(SetExtruderFanPin, 0x1);
 pinMode(CONTROLLINO_AO0, 0x1);
 digitalWrite(ExtruderTempVoltagePin, 0x1);
 digitalWrite(enblPin, 0x1);
 digitalWrite(dirPin, 0x0);
 digitalWrite(SetExtruderFanPin, 0x0);
 analogWrite(CONTROLLINO_AO0, 255 / 2);
 Serial.begin(9600);
 mystepper.setMaxSpeed(20000);
 mystepper.setAcceleration(5000 * 409);
}

void ArduinoIO::Run()
{
 UpdateSerial();
 mystepper.run();
 bool inBewegung = false;
 inBewegung = mystepper.isRunning();
 Checkfinish(inBewegung);
 ExtruderTemperaturRegelung();
}

void ArduinoIO::UpdateSerial()
{
 if (Serial.available() > 0)
 {
  String choise = Serial.readStringUntil('&');
  String data = Serial.readStringUntil('&');

  if (data != "" && choise != "")
  {
   NewCommand(choise, data);
  }
 }
}

void ArduinoIO::NewCommand(String choise, String data)
{
 if (choise == "G1E")
 {
  SetMoveE(data.toFloat());
 }
 else if (choise == "G1F")
 {
  SetSpeed(data.toFloat());
 }
 else if (choise == "M104")
 {
  SetExtruderTemperatur(data.toFloat());
 }
 else if (choise == "")
 {

 }
}

void ArduinoIO::SetExtruderTemperatur(float Temperatur)
{
 this->zielExtruderTemperatur = Temperatur;
}

float ArduinoIO::GetExtruderTemperatur()
{
 double bWert = 4267;
 double widerstand1 = 100000.0;
 double widerstandNTC = 0;
 double kelvintemp = 273.15;
 double Tn = kelvintemp + 25;
 double TKelvin = 0;
 double T = 0;
 double* tempfeld = new double[100];
 


















# 150 "C:\\Users\\stein\\Downloads\\Yamaha3DPrint\\yamaha3Dprint\\ArduinoSensorIO\\ArduinoSensorIO\\ArduinoSensorIO.cpp"
 double bitwertNTC = (double)analogRead(ExtruderTempPin);
 widerstandNTC = widerstand1 * (bitwertNTC / 1024) / (1 - bitwertNTC / 1024);

 
 TKelvin = 1 / ((1 / Tn) + (1.0 / bWert) * log(widerstandNTC / widerstand1));

 
 T = TKelvin - kelvintemp; 

 Serial.println(bitwertNTC);
 return T;
}


