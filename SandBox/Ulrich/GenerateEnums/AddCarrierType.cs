using System.ComponentModel.DataAnnotations;

public enum AddCarrierType
{

   /// <summary>
   /// Unknown
   /// </summary>
   [Display(Name = @"Unknown")]
   Unknown,

   /// <summary>
   /// woven wrap
   /// </summary>
   [Display(Name = @"woven wrap")]
   WovenWrap,

   /// <summary>
   /// stretchy wrap
   /// </summary>
   [Display(Name = @"stretchy wrap")]
   StretchyWrap,

   /// <summary>
   /// hybrid wrap
   /// </summary>
   [Display(Name = @"hybrid wrap")]
   HybridWrap,

   /// <summary>
   /// ring sling
   /// </summary>
   [Display(Name = @"ring sling")]
   RingSling,

   /// <summary>
   /// mei tai
   /// </summary>
   [Display(Name = @"mei tai")]
   MeiTai,

   /// <summary>
   /// half buckle mei tai
   /// </summary>
   [Display(Name = @"half buckle mei tai")]
   HalfBuckleMeiTai,

   /// <summary>
   /// wrap tai
   /// </summary>
   [Display(Name = @"wrap tai")]
   WrapTai,

   /// <summary>
   /// half buckle wrap tai
   /// </summary>
   [Display(Name = @"half buckle wrap tai")]
   HalfBuckleWrapTai,

   /// <summary>
   /// onbuhimo
   /// </summary>
   [Display(Name = @"onbuhimo")]
   Onbuhimo,

   /// <summary>
   /// reverse onbuhimo
   /// </summary>
   [Display(Name = @"reverse onbuhimo")]
   ReverseOnbuhimo,

   /// <summary>
   /// buckle onbuhimo
   /// </summary>
   [Display(Name = @"buckle onbuhimo")]
   BuckleOnbuhimo,

   /// <summary>
   /// podeagi
   /// </summary>
   [Display(Name = @"podeagi")]
   Podeagi,

   /// <summary>
   /// nyia
   /// </summary>
   [Display(Name = @"nyia")]
   Nyia,

   /// <summary>
   /// doll sling
   /// </summary>
   [Display(Name = @"doll sling")]
   DollSling,

   /// <summary>
   /// other carrier
   /// </summary>
   [Display(Name = @"other carrier")]
   OtherCarrier,
}
