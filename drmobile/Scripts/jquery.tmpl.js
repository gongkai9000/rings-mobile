/*
 * jQuery Templates Plugin 1.0.0pre
 * http://github.com/jquery/jquery-tmpl
 * Requires jQuery 1.4.2
 *
 * Copyright Software Freedom Conservancy, Inc.
 * Dual licensed under the MIT or GPL Version 2 licenses.
 * http://jquery.org/license
 */
(function(Y,C){var I=Y.fn.domManip,M="_tmplitem",H=/^[^<]*(<[\w\W]+>)[^>]*$|\{\{\! /,V={},U={},B,X={key:0,data:{}},K=0,P=0,R=[];function S(c,d,b,e){var a={data:e||(d?d.data:{}),_wrap:d?d._wrap:null,tmpl:null,parent:d||null,nodes:[],calls:L,nest:O,wrap:G,html:A,update:W};if(c){Y.extend(a,c,{nodes:[],parent:d})}if(b){a.tmpl=b;a._ctnt=a._ctnt||a.tmpl(Y,a);a.key=++K;(R.length?U:V)[K]=a}return a}Y.each({appendTo:"append",prependTo:"prepend",insertBefore:"before",insertAfter:"after",replaceAll:"replaceWith"},function(b,a){Y.fn[b]=function(h){var k=[],e=Y(h),j,d,g,c,f=this.length===1&&this[0].parentNode;B=V||{};if(f&&f.nodeType===11&&f.childNodes.length===1&&e.length===1){e[a](this[0]);k=this}else{for(d=0,g=e.length;d<g;d++){P=d;j=(d>0?this.clone(true):this).get();Y(e[d])[a](j);k=k.concat(j)}P=0;k=this.pushStack(k,b,e.selector)}c=B;B=null;Y.tmpl.complete(c);return k}});Y.fn.extend({tmpl:function(c,a,b){return Y.tmpl(this[0],c,a,b)},tmplItem:function(){return Y.tmplItem(this[0])},template:function(a){return Y.template(a,this[0])},domManip:function(a,j,b,e){if(a[0]&&Y.isArray(a[0])){var c=Y.makeArray(arguments),g=a[0],f=g.length,d=0,h;while(d<f&&!(h=Y.data(g[d++],"tmplItem"))){}if(h&&P){c[2]=function(i){Y.tmpl.afterManip(this,i,b)}}I.apply(this,c)}else{I.apply(this,arguments)}P=0;if(!B){Y.tmpl.complete(V)}return this}});Y.extend({tmpl:function(d,f,b,c){var e,a=!c;if(a){c=X;d=Y.template[d]||Y.template(null,d);U={}}else{if(!d){d=c.tmpl;V[c.key]=c;c.nodes=[];if(c.wrapped){T(c,c.wrapped)}return Y(J(c,null,c.tmpl(Y,c)))}}if(!d){return[]}if(typeof f==="function"){f=f.call(c||{})}if(b&&b.wrapped){T(b,b.wrapped)}e=Y.isArray(f)?Y.map(f,function(g){return g?S(b,c,d,g):null}):[S(b,c,d,f)];return a?Y(J(c,null,e)):e},tmplItem:function(b){var a;if(b instanceof Y){b=b[0]}while(b&&b.nodeType===1&&!(a=Y.data(b,"tmplItem"))&&(b=b.parentNode)){}return a||X},template:function(a,b){if(b){if(typeof b==="string"){b=Q(b)}else{if(b instanceof Y){b=b[0]||{}}}if(b.nodeType){b=Y.data(b,"tmpl")||Y.data(b,"tmpl",Q(b.innerHTML))}return typeof a==="string"?(Y.template[a]=b):b}return a?(typeof a!=="string"?Y.template(null,a):(Y.template[a]||Y.template(null,H.test(a)?a:Y(a)))):null},encode:function(a){return(""+a).split("<").join("&lt;").split(">").join("&gt;").split('"').join("&#34;").split("'").join("&#39;")}});Y.extend(Y.tmpl,{tag:{"tmpl":{_default:{$2:"null"},open:"if($notnull_1){__=__.concat($item.nest($1,$2));}"},"wrap":{_default:{$2:"null"},open:"$item.calls(__,$1,$2);__=[];",close:"call=$item.calls();__=call._.concat($item.wrap(call,__));"},"each":{_default:{$2:"$index, $value"},open:"if($notnull_1){$.each($1a,function($2){with(this){",close:"}});}"},"if":{open:"if(($notnull_1) && $1a){",close:"}"},"else":{_default:{$1:"true"},open:"}else if(($notnull_1) && $1a){"},"html":{open:"if($notnull_1){__.push($1a);}"},"=":{_default:{$1:"$data"},open:"if($notnull_1){__.push($.encode($1a));}"},"!":{open:""}},complete:function(a){V={}},afterManip:function Z(c,b,a){var d=b.nodeType===11?Y.makeArray(b.childNodes):b.nodeType===1?[b]:[];a.call(c,b);N(d);P++}});function J(a,c,e){var b,d=e?Y.map(e,function(f){return(typeof f==="string")?(a.key?f.replace(/(<\w+)(?=[\s>])(?![^>]*_tmplitem)([^>]*)/g,"$1 "+M+'="'+a.key+'" $2'):f):J(f,a,f._ctnt)}):a;if(c){return d}d=d.join("");d.replace(/^\s*([^<\s][^<]*)?(<[\w\W]+>)([^>]*[^>\s])?\s*$/,function(f,g,i,h){b=Y(i).get();N(b);if(g){b=F(g).concat(b)}if(h){b=b.concat(F(h))}});return b?b:F(d)}function F(b){var a=document.createElement("div");a.innerHTML=b;return Y.makeArray(a.childNodes)}function Q(a){return new Function("jQuery","$item","var $=jQuery,call,__=[],$data=$item.data;with($data){__.push('"+Y.trim(a).replace(/([\\'])/g,"\\$1").replace(/[\r\t\n]/g," ").replace(/\$\{([^\}]*)\}/g,"{{= $1}}").replace(/\{\{(\/?)(\w+|.)(?:\(((?:[^\}]|\}(?!\}))*?)?\))?(?:\s+(.*?)?)?(\(((?:[^\}]|\}(?!\}))*?)\))?\s*\}\}/g,function(d,l,i,c,h,e,b){var g=Y.tmpl.tag[i],j,k,f;if(!g){throw"Template command not found: "+i}j=g._default||[];if(e&&!/\w$/.test(h)){h+=e;e=""}if(h){h=D(h);b=b?(","+D(b)+")"):(e?")":"");k=e?(h.indexOf(".")>-1?h+D(e):("("+h+").call($item"+b)):h;f=e?k:"(typeof("+h+")==='function'?("+h+").call($item):("+h+"))"}else{f=k=j.$1||"null"}c=D(c);return"');"+g[l?"close":"open"].split("$notnull_1").join(h?"typeof("+h+")!=='undefined' && ("+h+")!=null":"true").split("$1a").join(f).split("$1").join(k).split("$2").join(c||j.$2||"")+"__.push('"})+"');}return __;")}function T(b,a){b._wrap=J(b,true,Y.isArray(a)?a:[H.test(a)?a:Y(a).html()]).join("")}function D(a){return a?a.replace(/\\'/g,"'").replace(/\\\\/g,"\\"):null}function E(a){var b=document.createElement("div");b.appendChild(a.cloneNode(true));return b.innerHTML}function N(j){var d="_"+P,c,h,a={},e,f,g;for(e=0,f=j.length;e<f;e++){if((c=j[e]).nodeType!==1){continue}h=c.getElementsByTagName("*");for(g=h.length-1;g>=0;g--){b(h[g])}b(c)}function b(i){var l,p=i,n,o,k;if((k=i.getAttribute(M))){while(p.parentNode&&(p=p.parentNode).nodeType===1&&!(l=p.getAttribute(M))){}if(l!==k){p=p.parentNode?(p.nodeType===11?0:(p.getAttribute(M)||0)):0;if(!(o=V[k])){o=U[k];o=S(o,V[p]||U[p]);o.key=++K;V[K]=o}if(P){m(k)}}i.removeAttribute(M)}else{if(P&&(o=Y.data(i,"tmplItem"))){m(o.key);V[o.key]=o;p=Y.data(i.parentNode,"tmplItem");p=p?p.key:0}}if(o){n=o;while(n&&n.key!=p){n.nodes.push(i);n=n.parent}delete o._ctnt;delete o._wrap;Y.data(i,"tmplItem",o)}function m(q){q=q+d;o=a[q]=(a[q]||S(o,V[o.parent.key+d]||o.parent))}}}function L(c,a,d,b){if(!c){return R.pop()}R.push({_:c,tmpl:a,item:this,data:d,options:b})}function O(b,c,a){return Y.tmpl(Y.template(b),c,a,this)}function G(b,a){var c=b.options||{};c.wrapped=a;return Y.tmpl(Y.template(b.tmpl),b.data,c,b.item)}function A(c,b){var a=this._wrap;return Y.map(Y(Y.isArray(a)?a.join(""):a).filter(c||"*"),function(d){return b?d.innerText||d.textContent:d.outerHTML||E(d)})}function W(){var a=this.nodes;Y.tmpl(null,null,null,this).insertBefore(a[0]);Y(a).remove()}})(jQuery);